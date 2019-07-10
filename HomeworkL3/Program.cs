using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace HomeworkL3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter numbers: ");
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Console.WriteLine("Sum: " + numbers.Sum());
        }
    }
}
