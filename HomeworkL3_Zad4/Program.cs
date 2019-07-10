using System;
using System.Linq;

namespace HomeworkL3_Zad4
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            string[] symbols = Console.ReadLine().Split().ToArray();

            if (numbers.FirstOrDefault() < numbers.ElementAtOrDefault(1))
            {
                for (int i = numbers.FirstOrDefault(); i < numbers.ElementAtOrDefault(1); i++)
                {
                    for (int j = 0; j < symbols.Length; j++)
                    {
                        if (symbols.ElementAtOrDefault(j) == ((char)i).ToString())
                        {
                            Console.Write(symbols.ElementAtOrDefault(j) + " ");
                            break;
                        }
                    }
                }
                Console.Write(Environment.NewLine);
            }
        }
    }
}
