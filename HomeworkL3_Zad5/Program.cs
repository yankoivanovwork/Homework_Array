using System;
using System.Linq;

namespace HomeworkL3_Zad5
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] password = Console.ReadLine().ToCharArray();
            bool[] condition = new bool[5];

            for (int i = 0; i < password.Length; i++)
            {
                if (password.Length >= 6)
                {
                    condition[0] = true;
                }
                if (char.IsDigit(password.ElementAtOrDefault(i)))
                {
                    condition[1] = true;
                }
                if (char.IsLower(password.ElementAtOrDefault(i)))
                {
                    condition[2] = true;
                }
                if (char.IsUpper(password.ElementAtOrDefault(i)))
                {
                    condition[3] = true;
                }
                if (char.IsSymbol(password.ElementAtOrDefault(i)) || char.IsPunctuation(password.ElementAtOrDefault(i)))
                {
                    condition[4] = true;
                }
            }

            if (condition.All(x => x == true))
            {
                Console.WriteLine("Силна парола!");
            }
            else if (!condition.Contains(true))
            {
                Console.WriteLine("False, паролата не отговаря на нито едно от посочените условия!");
            }
            else
            {
                Console.Write("False, Паролата не изпълнява следните условия:");
                Console.Write(condition.FirstOrDefault() == false ? " да съдържа минимум от 6 символа," : string.Empty);
                Console.Write(condition.ElementAtOrDefault(1) == false ? " поне една цифра," : string.Empty);
                Console.Write(condition.ElementAtOrDefault(2) == false ? " поне една малка буква," : string.Empty);
                Console.Write(condition.ElementAtOrDefault(3) == false ? " поне една голяма буква," : string.Empty);
                Console.Write(condition.ElementAtOrDefault(4) == false ? " поне един символ различен от цифра и буква" : string.Empty);
                Console.Write(".");
                Console.Write(Environment.NewLine);
            }
        }
    }
}
