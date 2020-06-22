using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomArray;

namespace CustomArrayUI
{
	class Program
	{
		static void Main(string[] args)
		{
			FreeIndexArray<int> MyArray = new FreeIndexArray<int>(3, 7);
			MyArray[3] = 3;
			MyArray[5] = 5;
			MyArray[7] = 7;
			for (int i = 3; i <= MyArray.End; i++)
				Console.Write(MyArray[i].ToString(), " ");
			Console.WriteLine();
			Console.WriteLine();
			Console.WriteLine();
			Console.WriteLine();


			FreeIndexArray<string> MyArray2 = new FreeIndexArray<string>(3, 7);
			MyArray2[3] = "pipa";
			MyArray2[5] = "biba";
			MyArray2[7] = "boba";
			//for (int i = 3; i <= MyArray2.End; i++)
			//	Console.Write(MyArray2[i], " ");
			Console.WriteLine(MyArray2[3]);
			Console.WriteLine(MyArray2[5]);
			Console.WriteLine(MyArray2[7]);

			Console.ReadKey();
		}
	}
}
