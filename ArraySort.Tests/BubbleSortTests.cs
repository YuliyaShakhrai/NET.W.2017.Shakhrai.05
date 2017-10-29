using System;
using NUnit.Framework;
using static ArraySort.Tests.CompareLibrary;
using System.Linq;

namespace ArraySort.Tests
{
    [TestFixture]
    public class BubbleSortTests
    {
        #region SortByElementSumTest
        static object[] SortByElementSumUp =
        {
            new object[] { new int[][] { new int[] { 1, 3, 5, 7, 9 }, new int[] { 0, 2, 4, 6 }, new int[] { 11, 22 } }, new int[][] { new int[] { 0, 2, 4, 6 }, new int[] { 1, 3, 5, 7, 9 }, new int[] {11,22}}, new CompareBySumUp() },
            new object[] { new int[][] { new int[] {15, 17,0,68}, new int[] { 17, 2, 9 }, new int[] { 20, 21 } }, new int[][] { new int[] { 17, 2, 9 }, new int[] { 20, 21 }, new int[] { 15, 17, 0, 68 } }, new CompareBySumUp() }
        };

        static object[] SortByElementSumDown =
        {
            new object[] { new int[][] { new int[] { 1, 3, 5, 7, 9 }, new int[] { 0, 2, 4, 6 }, new int[] { 11, 22 } }, new int[][] { new int[] { 11, 22 }, new int[] { 1, 3, 5, 7, 9 }, new int[] { 0, 2, 4, 6 } }, new CompareBySumDown() },
            new object[] { new int[][] { new int[] { 17, 2, 9 }, new int[] { 15, 17, 0, 68 }, new int[] { 20, 21 } }, new int[][] { new int[] { 15, 17, 0, 68 }, new int[] { 20, 21 }, new int[] { 17, 2, 9 } }, new CompareBySumDown() }
        };

        [Test, TestCaseSource("SortByElementSumUp")]
        public void SortByElementSumUp_PositivTest(int[][] actual, int[][] expected, IComparer comparer)
        {
            BubbleSortInterfaceToDelegate.Sort(actual, comparer);
            Assert.AreEqual(expected, actual);
        }

        [Test, TestCaseSource("SortByElementSumUp")]
        public void SortByElementSumUpItoD_PositivTest(int[][] actual, int[][] expected, IComparer comparer)
        {
            BubbleSortInterfaceToDelegate.Sort(actual, comparer);
            Assert.AreEqual(expected, actual);
        }

        [Test, TestCaseSource("SortByElementSumUp")]
        public void SortByElementSumUpItoDDelegate_PositivTest(int[][] actual, int[][] expected, IComparer comparer)
        {
            BubbleSortInterfaceToDelegate.Sort(actual, delegate (int[] array1, int[] array2)
            {
                if ((array1 == null) || (array2 == null))
                    throw new ArgumentNullException();
                if (ReferenceEquals(array1, array2)) return 0;
                if (array1.Sum() > array2.Sum())
                    return 1;
                else if ((array1.Sum() < array2.Sum()))
                    return -1;
                else
                    return 0;
            });
            Assert.AreEqual(expected, actual);
        }

        [Test, TestCaseSource("SortByElementSumDown")]
        public void SortByElementSumDown_PositivTest(int[][] actual, int[][] expected, IComparer comparer)
        {
            BubbleSortInterfaceToDelegate.Sort(actual, comparer);
            Assert.AreEqual(expected, actual);
        }


        [Test, TestCaseSource("SortByElementSumUp")]
        public void SortByElementSumUpDelegate_PositivTest(int[][] actual, int[][] expected, IComparer comparer)
        {
            BubbleSortInterfaceToDelegate.Sort(actual, delegate (int[] arr1, int[] arr2)
            {
                if ((arr1 == null) || (arr2 == null))
                    throw new ArgumentNullException();
                if (ReferenceEquals(arr1, arr2)) return 0;
                if (arr1.Sum() > arr2.Sum())
                    return 1;
                else if ((arr1.Sum() < arr2.Sum()))
                    return -1;
                else
                    return 0;
            });
            Assert.AreEqual(expected, actual);
        }
        #endregion

        #region SortByMaxElementTest
        static object[] SortByMaxElementUp =
        {
            new object[] { new int[][] { new int[] { 1, 3, 5, 7, 9 }, new int[] { 0, 2, 4, 6 }, new int[] { 11, 22 } }, new int[][] { new int[] { 0, 2, 4, 6 }, new int[] { 1, 3, 5, 7, 9 }, new int[] {11,22}}, new CompareByMaxUp() },
            new object[] { new int[][] { new int[] {15, 17,0,68}, new int[] { 17, 2, 9 }, new int[] { 20, 21 } }, new int[][] { new int[] { 17, 2, 9 }, new int[] { 20, 21 }, new int[] { 15, 17, 0, 68 } }, new CompareByMaxUp() }
        };

        static object[] SortByMaxElementDown =
        {
            new object[] { new int[][] { new int[] { 1, 3, 5, 7, 9 }, new int[] { 0, 2, 4, 6 }, new int[] { 11, 22 } }, new int[][] { new int[] { 11, 22 }, new int[] { 1, 3, 5, 7, 9 }, new int[] { 0, 2, 4, 6 } }, new CompareByMaxDown() },
            new object[] { new int[][] { new int[] { 17, 2, 9 }, new int[] { 15, 17, 0, 68 }, new int[] { 20, 21 } }, new int[][] { new int[] { 15, 17, 0, 68 }, new int[] { 20, 21 }, new int[] { 17, 2, 9 } }, new CompareByMaxDown() }
        };

        [Test, TestCaseSource("SortByMaxElementUp")]
        public void SortByMaxElementUp_PositivTest(int[][] actual, int[][] expected, IComparer comparer)
        {
            BubbleSortInterfaceToDelegate.Sort(actual, comparer);
            Assert.AreEqual(expected, actual);
        }

        [Test, TestCaseSource("SortByMaxElementDown")]
        public void SortByMaxElementDown_PositivTest(int[][] actual, int[][] expected, IComparer comparer)
        {
            BubbleSortInterfaceToDelegate.Sort(actual, comparer);
            Assert.AreEqual(expected, actual);
        }
        #endregion

    }
}
