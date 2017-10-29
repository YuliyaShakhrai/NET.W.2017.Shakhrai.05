using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArraySort
{
    /// <summary>
    /// Defines a method that a type implements to compare two objects
    /// </summary>
    public interface IComparer
    {
        /// <summary>
        /// Compares two integer arrays by the given feature
        /// </summary>
        /// <param name = "lhs">First array for comparison</param>
        /// <param name = "rhs">Second array for comparison</param>
        /// <returns>Integer result of comparison</returns>
        int Compare(int[] lhs, int[] rhs);
    }
}
