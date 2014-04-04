using System.IO;
using System.Threading;

namespace ProScan
{
	public abstract class CommPingPong : CommBase
	{
		private ManualResetEvent TransFlag = new ManualResetEvent(true);
		private byte[] RxByte;
		private uint TransTimeout;

		protected byte Transact(byte toSend)
		{
			if (RxByte == null)
				RxByte = new byte[1];
			Send(toSend);
			TransFlag.Reset();
			if (!TransFlag.WaitOne((int)TransTimeout, false))
				ThrowException("Timeout");
			lock (RxByte)
				return RxByte[0];
		}

		protected void Setup(CommPingPong.CommPingPongSettings s)
		{
			TransTimeout = (uint)s.transactTimeout;
		}

		protected override void OnRxChar(byte ch)
		{
			lock (RxByte)
				RxByte[0] = ch;
			if (TransFlag.WaitOne(0, false))
				return;
			TransFlag.Set();
		}

		public class CommPingPongSettings : CommBase.CommBaseSettings
		{
			public int transactTimeout = 500;

			public new static CommPingPong.CommPingPongSettings LoadFromXML(Stream s)
			{
				return (CommPingPong.CommPingPongSettings)CommBase.CommBaseSettings.LoadFromXML(s, typeof(CommPingPong.CommPingPongSettings));
			}
		}
	}
}
