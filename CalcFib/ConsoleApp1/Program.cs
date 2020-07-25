using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("I will calculate the nth Fibonacci number.");
            int n = GetN();
            int f = CalcFib(n);
            Console.WriteLine("The {0}th Finonacci number is: {1}", n, f);
            Console.WriteLine("");
            Console.Write("Press any key to exit...");
            Console.ReadKey();
        }

        /// <summary>
        /// Keeps asking for console input until a valid non-neagative number is provided. This recusive function does not use any while or for loops
        /// </summary>
        /// <returns></returns>
        private static int GetN()
        {
            Console.Write("Enter value for n: ");
            string l = Console.ReadLine();
            int n;
            if (Int32.TryParse(l, out n))
            {
                if (n >= 0)
                {
                    return n;
                }
            }
            Console.WriteLine("Invalid input!\nn must be a non-negative number.\nPlease try again.");
            return GetN();
        }

        /// <summary>
        /// Calculates nth Fibonacci number. {0, 1, 1, 2, 3, 5, 8, 13, ...}
        /// </summary>
        /// <param name="n">Value for n to calculate. Must be non-negative</param>
        /// <returns>nth Fibonacci number</returns>
        private static int CalcFib(int n)
        {
            if (n < 0)
            {
                throw new Exception("n must be >= 0");
            }

            // 0, 1, 1, 2, 3, 5, 8, 13, ...
            if (n == 0 || n == 1)
            {
                return n;
            }
            else
            {
                return CalcFib(n - 1) + n;
            }
        }
    }
}
