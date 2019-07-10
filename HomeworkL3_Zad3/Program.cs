using System;
using System.Globalization;
using System.Linq;

namespace HomeworkL3_Zad3
{
    class Program
    {
        static void Main(string[] args)
        {
            CultureInfo customCulture = (CultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture.Clone();
            customCulture.NumberFormat.NumberDecimalSeparator = ".";
            System.Threading.Thread.CurrentThread.CurrentCulture = customCulture;

            Console.Write("Enter n number: ");
            int.TryParse(Console.ReadLine(), out int n);
            double[] numbers = new double[n];
            Console.Write("Enter numbers: ");
            string readLine = Console.ReadLine();

            if (readLine.Split().Count() == n)
            {
                numbers = readLine.Split().Select(double.Parse).ToArray();

                double minNumber = 0;
                double maxNumber = 0;

                for (int i = 0; i < numbers.Length; i++)
                {
                    if (i == 0)
                    {
                        minNumber = numbers.FirstOrDefault();
                        maxNumber = numbers.FirstOrDefault();
                    }
                    else
                    {
                        if (minNumber > numbers.ElementAtOrDefault(i))
                        {
                            minNumber = numbers.ElementAtOrDefault(i);
                        }
                        if (maxNumber < numbers.ElementAtOrDefault(i))
                        {
                            maxNumber = numbers.ElementAtOrDefault(i);
                        }
                    }
                }

                Console.WriteLine(minNumber + ", " + maxNumber + ", " + (numbers.Sum()/numbers.Length));
            }
        }
    }
}
