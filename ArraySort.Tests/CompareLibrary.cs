using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ArraySort.Tests
{
    class CompareLibrary
    {
        public class CompareBySumUp : IComparer
        {
            public int Compare(int[] array1, int[] array2)
            {
                if ((array1 == null) || (array2 == null)) throw new ArgumentNullException("One of arrays is null.");
                if (ReferenceEquals(array1, array2)) return 0;
                if (array1.Sum() > array2.Sum())
                    return 1;
                else if ((array1.Sum() < array2.Sum()))
                    return -1;
                else
                    return 0;
            }
        }

        public class CompareBySumDown : IComparer
        {
            public int Compare(int[] arr1, int[] arr2)
            {
                if ((arr1 == null) || (arr2 == null)) throw new ArgumentNullException("One of arrays is null.");
                if (ReferenceEquals(arr1, arr2)) return 0;
                if (arr1.Sum() > arr2.Sum())
                    return -1;
                else if ((arr1.Sum() < arr2.Sum()))
                    return 1;
                else
                    return 0;
            }
        }

        public class CompareByMaxUp : IComparer
        {
            public int Compare(int[] arr1, int[] arr2)
            {
                if ((arr1 == null) || (arr2 == null)) throw new ArgumentNullException("One of arrays is null.");
                if (ReferenceEquals(arr1, arr2)) return 0;
                if (arr1.Max() > arr2.Max())
                    return 1;
                else if ((arr1.Max() < arr2.Max()))
                    return -1;
                else
                    return 0;
            }
        }

        public class CompareByMaxDown : IComparer
        {
            public int Compare(int[] arr1, int[] arr2)
            {
                if ((arr1 == null) || (arr2 == null)) throw new ArgumentNullException("One of arrays is null.");
                if (ReferenceEquals(arr1, arr2)) return 0;
                if (arr1.Max() > arr2.Max())
                    return -1;
                else if ((arr1.Max() < arr2.Max()))
                    return 1;
                else
                    return 0;
            }
        }
    }
}
