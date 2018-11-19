using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedConsoleApplicationII
{
    /// <summary>
    /// The Utilities class contains common utilities for the project
    /// </summary>
    public static class Utilities
    {
        /// <summary>
        /// This method Swaps generic types based on reference
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="a">First parameter of type T to swap with second</param>
        /// <param name="b">Second parameter of type T to swap with first</param>
        public static void Swap<T>(ref T a, ref T b)
        {
            T temp = b;
            b = a;
            a = temp;
        } // end of method

    } // end of class
} // end of namespace
