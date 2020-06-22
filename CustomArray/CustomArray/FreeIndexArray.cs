using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomArray
{
    public partial class FreeIndexArray<T>
    {
		Cell Root;
		public int Beg { get; }
		public int End { get; }
		public FreeIndexArray(int a, int b)
		{
			if (a > b)
			{
				Beg = b;
				End = a;
			}
			else
			{
				Beg = a;
				End = b;
			}
			Root = new Cell();
			CreateElements(Root, End - Beg);
		}
		void CreateElements(Cell currentelement, int i)
		{
			if (i >= 0)
			{
				currentelement.Next = new Cell();
				CreateElements(currentelement.Next, --i);
			}
		}
		public T this[int i]
		{
			get
			{
				if ((i < Beg) || (i > End))
					throw new IndexOutOfCustomArrayRangeException("Index is out of Array range");
				Cell res;
				int k = i - Beg;
				if (k > 0)
					EjectElement(out res, Root, k);
				else
					res = Root;
				return res.Data;
			}
			set
			{
				if ((i < Beg) || (i > End))
					throw new IndexOutOfCustomArrayRangeException("Index is out of Array range");
				int k = i - Beg;
				Cell cp;
				if (k > 0)
					EjectElement(out cp, Root, k);
				else
				{
					cp = Root;
				}
				cp.Data = value;
			}
		}
		void EjectElement(out Cell res, Cell currentelement, int i)
		{
			if (i > 0)
				EjectElement (out res, currentelement.Next, --i);
			else
				res = currentelement;
		}
    }
}
