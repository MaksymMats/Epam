using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CustomArray;

namespace CustomArrayTests
{
	[TestClass]
	public class FreeIndexArrayTests
	{
		[DataRow(0, 0, 0, 0)]
		[DataRow(5, 5, 5, 5)]
		[DataRow(0, 5, 0, 5)]
		[DataRow(5, 0, 0, 5)]
		[DataRow(3, 7, 3, 7)]
		[DataRow(7, 3, 3, 7)]
		[DataRow(-5, 5, -5, 5)]
		[DataRow(5, -5, -5, 5)]
		[DataTestMethod]
		public void TestConstructorWithBeginAndEndIndexes(int a, int b, int expBeg, int expEnd)
		{
			//arrange
			FreeIndexArray<int> TestArray = new FreeIndexArray<int>(a, b);

			//act
			int actualBeg = TestArray.Beg;
			int actualEnd = TestArray.End;

			//assert
			Assert.AreEqual(expBeg, actualBeg, "Start index of array is not correct");
			Assert.AreEqual(expEnd, actualEnd, "End index of array is not correct");
		}

		[DataRow(3, 7)]
		[DataRow(6, 6)]
		[DataRow(7, 3)]
		[DataRow(-5, 5)]
		[DataTestMethod]
		public void	InitialisationOfArrayMustCreateCellForEveryElementInArray(int a, int b)
		{
			//arrange
			FreeIndexArray<int> TestArray = new FreeIndexArray<int>(a, b);
			int testint;

			//act
			for (int i = TestArray.Beg; i <= TestArray.End; i++)
			{
				testint = TestArray[i];
			}
		}
		[DataRow(3, 7, 0)]
		[DataRow(6, 6, 7)]
		[DataTestMethod]
		[ExpectedException(typeof(IndexOutOfCustomArrayRangeException))]
		public void EjectingValuesFromArrayOutOfInilialRangeShouldCauseIndexOutOfCustomArrayRangeException(int a, int b, int exp)
		{
			//arrange
			FreeIndexArray<int> TestArray = new FreeIndexArray<int>(a, b);

			//act
			int i = TestArray[exp];
		}
	}
}
