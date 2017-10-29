using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArraySort
{
    internal class CompareByDelegate : IComparer
    {
        private Comparison<int[]> comparer;
        public CompareByDelegate(Comparison<int[]> del)
        {
            comparer = del;
        }
        public int Compare(int[] array1, int[] array2)
        {
            return comparer(array1, array2);
        }
    }
}
