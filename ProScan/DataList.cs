internal class DataList
{
	private DataNode pHead;
	private DataNode pTail;
	private int iTotalNodes;

	public DataList()
	{
		pHead = (DataNode)null;
		pTail = (DataNode)null;
		iTotalNodes = 0;
	}

	public void Insert(double value, long iTicks)
	{
		DataNode dataNode = new DataNode();
		dataNode.pData = new DataItem(value, iTicks);
		if (pHead == null)
		{
			pHead = dataNode;
			dataNode.pPrev = (DataNode)null;
		}
		else
		{
			pTail.pNext = dataNode;
			dataNode.pPrev = pTail;
		}
		pTail = dataNode;
		dataNode.pNext = (DataNode)null;
		iTotalNodes = iTotalNodes + 1;
	}

	public void Insert(double value)
	{
		DataNode dataNode = new DataNode();
		dataNode.pData = new DataItem(value);
		if (pHead == null)
		{
			pHead = dataNode;
			dataNode.pPrev = (DataNode)null;
		}
		else
		{
			pTail.pNext = dataNode;
			dataNode.pPrev = pTail;
		}
		pTail = dataNode;
		dataNode.pNext = (DataNode)null;
		iTotalNodes = iTotalNodes + 1;
	}

	public DataItem GetItem(int index)
	{
		if (index >= iTotalNodes)
			return (DataItem)null;
		DataNode dataNode = pHead;
		if (0 < index)
		{
			uint num = (uint)index;
			do
			{
				dataNode = dataNode.pNext;
				--num;
			}
			while (num > 0U);
		}
		return dataNode.pData;
	}

	public double GetValue(int index)
	{
		if (index >= iTotalNodes)
			return -1.0;
		DataNode dataNode = pHead;
		if (0 < index)
		{
			uint num = (uint)index;
			do
			{
				dataNode = dataNode.pNext;
				--num;
			}
			while (num > 0U);
		}
		return dataNode.pData.Value;
	}

	public long GetTicks(int index)
	{
		if (index >= iTotalNodes)
			return -1L;
		DataNode dataNode = pHead;
		if (0 < index)
		{
			uint num = (uint)index;
			do
			{
				dataNode = dataNode.pNext;
				--num;
			}
			while (num > 0U);
		}
		return dataNode.pData.Ticks;
	}

	public double GetSeconds(int index)
	{
		if (index >= iTotalNodes)
			return -1.0;
		DataNode dataNode = pHead;
		if (0 < index)
		{
			uint num = (uint)index;
			do
			{
				dataNode = dataNode.pNext;
				--num;
			}
			while (num > 0U);
		}
		return (double)(dataNode.pData.Ticks - pHead.pData.Ticks) * 1E-07;
	}

	public int TotalItems()
	{
		return iTotalNodes;
	}

	public void Reset()
	{
		if (pTail != null)
		{
			do
			{
				pTail = pTail.pPrev;
			}
			while (pTail != null);
		}
		pHead = (DataNode)null;
		pTail = (DataNode)null;
		iTotalNodes = 0;
	}
}
