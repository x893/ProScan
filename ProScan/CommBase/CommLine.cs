using System.IO;
using System.Text;
using System.Threading;

namespace ProScan
{
	public abstract class CommLine : CommBase
	{
		private uint RxBufferP = 0U;
		private string RxString = "";
		private ManualResetEvent TransFlag = new ManualResetEvent(true);
		private byte[] RxBuffer;
		private CommBase.ASCII RxTerm;
		private CommBase.ASCII[] TxTerm;
		private CommBase.ASCII[] RxFilter;
		private uint TransTimeout;

		protected void Send(string toSend)
		{
			int num = Encoding.ASCII.GetByteCount(toSend);
			if (TxTerm != null)
				num += TxTerm.GetLength(0);
			byte[] tosend = new byte[num];
			byte[] bytes = Encoding.ASCII.GetBytes(toSend);
			int index1;
			for (index1 = 0; index1 <= bytes.GetUpperBound(0); ++index1)
				tosend[index1] = bytes[index1];
			if (TxTerm != null)
			{
				int index2 = 0;
				while (index2 <= TxTerm.GetUpperBound(0))
				{
					tosend[index1] = (byte)TxTerm[index2];
					++index2;
					++index1;
				}
			}
			base.Send(tosend);
		}

		protected string Transact(string toSend)
		{
			Send(toSend);
			TransFlag.Reset();
			if (!TransFlag.WaitOne((int)TransTimeout, false))
				ThrowException("Timeout");
			lock (RxString)
				return RxString;
		}

		protected void Setup(CommLine.CommLineSettings s)
		{
			RxBuffer = new byte[s.rxStringBufferSize];
			RxTerm = s.rxTerminator;
			RxFilter = s.rxFilter;
			TransTimeout = (uint)s.transactTimeout;
			TxTerm = s.txTerminator;
		}

		protected virtual void OnRxLine(string s)
		{
		}

		protected override void OnRxChar(byte ch)
		{
			CommBase.ASCII ascii = (CommBase.ASCII)ch;
			if (ascii == RxTerm || (long)RxBufferP > (long)RxBuffer.GetUpperBound(0))
			{
				lock (RxString)
					RxString = Encoding.ASCII.GetString(RxBuffer, 0, (int)RxBufferP);
				RxBufferP = 0U;
				if (TransFlag.WaitOne(0, false))
					OnRxLine(RxString);
				else
					TransFlag.Set();
			}
			else
			{
				bool flag = true;
				if (RxFilter != null)
				{
					for (int index = 0; index <= RxFilter.GetUpperBound(0); ++index)
					{
						if (RxFilter[index] == ascii)
							flag = false;
					}
				}
				if (!flag)
					return;
				RxBuffer[RxBufferP] = ch;
				++RxBufferP;
			}
		}

		public class CommLineSettings : CommBase.CommBaseSettings
		{
			public int rxStringBufferSize = 256;
			public CommBase.ASCII rxTerminator = CommBase.ASCII.CR;
			public int transactTimeout = 500;
			public CommBase.ASCII[] rxFilter;
			public CommBase.ASCII[] txTerminator;

			public new static CommLine.CommLineSettings LoadFromXML(Stream s)
			{
				return (CommLine.CommLineSettings)CommBase.CommBaseSettings.LoadFromXML(s, typeof(CommLine.CommLineSettings));
			}
		}
	}
}
