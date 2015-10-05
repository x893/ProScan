using System.IO;
using System.Text;
using System.Threading;

namespace ProScan
{
	public abstract class CommLine : CommBase
	{
		private int m_RxIndex = 0;
		private string m_RxString = "";
		private ManualResetEvent m_TransFlag = new ManualResetEvent(true);
		private byte[] m_RxBuffer;
		private CommBase.ASCII m_RxTerm;
		private CommBase.ASCII[] m_TxTerm;
		private CommBase.ASCII[] m_RxFilter;
		private int m_TransTimeout;

		protected void Send(string data)
		{
			int len_data = Encoding.ASCII.GetByteCount(data);

			int len_term = 0;
			if (m_TxTerm != null)
				len_term = m_TxTerm.Length;

			byte[] sending = new byte[len_data + len_term];
			Encoding.ASCII.GetBytes(data).CopyTo(sending, 0);

			if (m_TxTerm != null)
				m_TxTerm.CopyTo(sending, len_data);
			base.Send(sending);
		}

		protected string Transact(string data)
		{
			Send(data);
			m_TransFlag.Reset();
			if (!m_TransFlag.WaitOne(m_TransTimeout, false))
				ThrowException("Timeout");
			lock (m_RxString)
				return m_RxString;
		}

		protected void Setup(CommLine.CommLineSettings settings)
		{
			m_RxBuffer = new byte[settings.RxStringBufferSize];
			m_RxTerm = settings.RxTerminator;
			m_RxFilter = settings.RxFilter;
			m_TransTimeout = settings.TransactTimeout;
			m_TxTerm = settings.TxTerminator;
		}

		protected virtual void OnRxLine(string s)
		{
		}

		protected override void OnRxChar(byte ch)
		{
			CommBase.ASCII ascii = (CommBase.ASCII)ch;
			if (ascii == m_RxTerm || m_RxIndex >= m_RxBuffer.Length)
			{
				lock (m_RxString)
					m_RxString = Encoding.ASCII.GetString(m_RxBuffer, 0, m_RxIndex);
				m_RxIndex = 0;
				if (m_TransFlag.WaitOne(0, false))
					OnRxLine(m_RxString);
				else
					m_TransFlag.Set();
			}
			else
			{
				if (m_RxFilter != null)
				{
					for (int idx = 0; idx < m_RxFilter.Length; ++idx)
						if (m_RxFilter[idx] == ascii)
							return;
				}
				m_RxBuffer[m_RxIndex] = ch;
				++m_RxIndex;
			}
		}

		public class CommLineSettings : CommBase.CommBaseSettings
		{
			public int RxStringBufferSize = 256;
			public CommBase.ASCII RxTerminator = CommBase.ASCII.CR;
			public int TransactTimeout = 500;
			public CommBase.ASCII[] RxFilter;
			public CommBase.ASCII[] TxTerminator;
		}
	}
}
