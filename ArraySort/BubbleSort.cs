using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArraySort
{
    /// <summary>
    /// Class sort array by bubble sort
    /// </summary>
    public static class BubbleSort
    {
        /// <summary>
        /// Class sort array by choosen condition
        /// </summary>
        /// <param name="array">Unsorted array</param>
        /// <param name="comparer">Sort condition</param>
        public static void Sort(int[][] array, IComparer comparer)
        {
            if ((array == null) || (comparer == null)) throw new ArgumentNullException("One of argument is null.");
            for (int i = 0; i < (array.Length - 1); i++)
                for (int j = 0; j < (array.Length - 1 - i); j++)
                    if (comparer.Compare(array[j], array[j + 1]) > 0)
                        Swap(ref array[j], ref array[j + 1]);
        }
        /// <summary>
        /// Class sort array by choosen condition
        /// </summary>
        /// <param name="array">Unsorted array</param>
        /// <param name="comparer">Sort condition</param>
        public static void Sort(int[][] array, Comparison<int[]> comparer)
        {
            if ((array == null) || (comparer == null)) throw new ArgumentNullException("One of argument is null.");
            Sort(array, (new CompareByDelegate(comparer)));
        }

        /// <summary>
        /// Swap to elements
        /// </summary>
        /// <param name="arr1">First element</param>
        /// <param name="arr2">Second element</param>
        private static void Swap(ref int[] arr1, ref int[] arr2)
        {
            int[] temp = arr1;
            arr1 = arr2;
            arr2 = temp;
        }

    }


    /// <summary>
    /// Class sort array by bubble sort
    /// </summary>
    public static class BubbleSortInterfaceToDelegate
    {
        /// <summary>
        /// Class sort array by choosen condition
        /// </summary>
        /// <param name="array">Unsorted array</param>
        /// <param name="comparer">Sort condition</param>
        public static void Sort(int[][] array, IComparer comparer)
        {
            if ((array == null) || (comparer == null)) throw new ArgumentNullException("One of argument is null.");
            Sort(array, comparer.Compare);
        }
        /// <summary>
        /// Class sort array by choosen condition
        /// </summary>
        /// <param name="array">Unsorted array</param>
        /// <param name="comparer">Sort condition</param>
        public static void Sort(int[][] array, Comparison<int[]> comparer)
        {
            if ((array == null) || (comparer == null)) throw new ArgumentNullException("One of argument is null.");
            for (int i = 0; i < (array.Length - 1); i++)
                for (int j = 0; j < (array.Length - 1 - i); j++)
                    if (comparer(array[j], array[j + 1]) > 0)
                        Swap(ref array[j], ref array[j + 1]);
        }

        /// <summary>
        /// Swap two elements
        /// </summary>
        /// <param name="array1">First element</param>
        /// <param name="array2">Second element</param>
        private static void Swap(ref int[] array1, ref int[] array2)
        {
            int[] temp = array1;
            array1 = array2;
            array2 = temp;
        }
    }
}

