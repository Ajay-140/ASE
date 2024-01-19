using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASEProject
{
    /// <summary>
    /// Math class for a program simulating a calculator
    /// </summary>

    internal class math
    {
        /// <summary>
        /// PI has value
        /// </summary>
        public const double PI = 3.14;

        /// <summary>
        /// Checks for an even integer
        /// </summary>
        /// <param name="num">Number being checked</param>
        /// <returns>True if even, false if uneven</returns>
        public static bool isEven(int num)
        {
            if (num % 2 == 0) return true;
            else return false;
        }
        static void Math()
        {
            int x = 10;

            // Example of a complex condition
            if (x > 5 && x % 2 == 0)
            {
                // Code to be executed if the condition is true
                Console.WriteLine("x is greater than 5 and even.");
            }
            // Closing brace marks the end of the block.

            // Code outside the if block
            Console.WriteLine("This runs regardless of the condition that is set.");

           
        }
    }
}
