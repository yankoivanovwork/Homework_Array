using System;
using System.Globalization;
using System.Linq;

namespace HomeworkL3_Zad2
{
    class Program
    {
        static void Main(string[] args)
        {
            //nachin1
            CultureInfo customCulture = (CultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture.Clone();
            customCulture.NumberFormat.NumberDecimalSeparator = ".";
            System.Threading.Thread.CurrentThread.CurrentCulture = customCulture;
            //---

            Console.Write("Enter n number: ");
            int.TryParse(Console.ReadLine(), out int n);
            double[] numbers = new double[n];
            Console.Write("Enter numbers: ");
            string readLine = Console.ReadLine();

            if (readLine.Split().Length == n)
            {
                numbers = readLine.Split().Select(double.Parse).ToArray();
                //nachin2
                //numbers = Console.ReadLine().Replace(".",",").Split().Select(decimal.Parse).ToArray();
                //-----------
                Console.WriteLine("Sum: " + numbers.Sum());
            }
        }
    }
}
