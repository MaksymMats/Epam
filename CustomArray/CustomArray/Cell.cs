using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomArray
{
	public partial class FreeIndexArray<T>
	{
		class Cell
		{
			public Cell Next;
			public T Data;
			public Cell()
			{
				Data = default;
			}
			public Cell(T data)
			{
				Data = data;
			}
		}
	}
}
