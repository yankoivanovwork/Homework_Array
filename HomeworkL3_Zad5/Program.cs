using System;
using System.Collections.Generic;
using System.Linq;

namespace HomeworkL3_Zad5
{
    class Program
    {
        static void Main(string[] args)
        {
            ///variant 0 - razlichna promenliva za vsqka proverka, masiv - pass

            ///variant 1 - dictionary
            Dictionary<Condition, bool> strongPasswordConditionDictionary = new Dictionary<Condition, bool>()
            {
                { Condition.isMoreThanSixDigits, false },
                { Condition.containsADigit, false },
                { Condition.containsLowercase, false },
                { Condition.containsUppercase, false },
                { Condition.containsSpecialCharacter, false }
            };
            ///------end dictionary

            ///variant 2 named tuple
            (bool aboveSixCharacters, bool containsNumber, bool containsLowercase, bool containsUppercase, bool containsSpecialCharacter) strongPasswordConditionTuple = (false, false, false, false, false);
            //var strongPasswordCondition = (aboveSixCharacters: false, containsNumber: false, containsLowercase: false, containsUppercase : false, containsSpecialCharacter : false);
            //strongPasswordConditionTuple.aboveSixCharacters = true;
            ///-----end named tuple

            Console.WriteLine("Въведете парола за тестване: ");
            string password = Console.ReadLine();

            strongPasswordConditionDictionary[Condition.isMoreThanSixDigits] = ValidatePasswordLength(password);

            for (int i = 0; i < password.Length; i++)
            {
                if (strongPasswordConditionDictionary[Condition.containsADigit] == false)
                {
                    strongPasswordConditionDictionary[Condition.containsADigit] = ValidatePasswordHasAleastOneDigit(password[i]);
                }

                if (strongPasswordConditionDictionary[Condition.containsLowercase] == false)
                {
                    strongPasswordConditionDictionary[Condition.containsLowercase] = ValidatePasswordHasLowerCaseChar(password[i]);
                }

                if (strongPasswordConditionDictionary[Condition.containsUppercase] == false)
                {
                    strongPasswordConditionDictionary[Condition.containsUppercase] = ValidatePasswordHasUpperCaseChar(password[i]);
                }

                if (strongPasswordConditionDictionary[Condition.containsSpecialCharacter] == false)
                {
                    strongPasswordConditionDictionary[Condition.containsSpecialCharacter] = ValidatePasswordHasSpecialChar(password[i]);
                }
            }

            Console.WriteLine(DisplayResult(strongPasswordConditionDictionary));
        }

        //Console.WriteLine("Contains Digit? .Any(): " + password.Any(char.IsDigit));

        private static bool ValidatePasswordLength(string password)
        {
            return password.Length >= 6 ? true : false;
        }

        private static bool ValidatePasswordHasAleastOneDigit(char password)
        {
            return char.IsDigit(password) ? true : false;
        }

        private static bool ValidatePasswordHasLowerCaseChar(char password)
        {
            return char.IsLower(password) ? true : false;
        }

        private static bool ValidatePasswordHasUpperCaseChar(char password)
        {
            return char.IsUpper(password) ? true : false;
        }

        private static bool ValidatePasswordHasSpecialChar(char password)
        {
            return (char.IsPunctuation(password) || char.IsSeparator(password)) ? true : false;
        }

        private static string DisplayResult(Dictionary<Condition, bool> strongPasswordConditionDictionary)
        {
            string displayString = string.Empty;
            bool isPasswordStrong = true;

            for (int i = 0; i < strongPasswordConditionDictionary.Count; i++)
            {
                if (!strongPasswordConditionDictionary.Values.ElementAtOrDefault(i))
                {
                    isPasswordStrong = false;
                    break;
                }
            }

            if (isPasswordStrong)
            {
                displayString = "Password is strong!";
            }
            else
            {
                displayString = "False, Паролата не изпълнява следните условия: ";
                if (!strongPasswordConditionDictionary[Condition.isMoreThanSixDigits])
                    displayString += " да съдържа минимум от 6 символа,";

                if (!strongPasswordConditionDictionary[Condition.containsADigit])
                    displayString += " поне една цифра,";

                if (!strongPasswordConditionDictionary[Condition.containsLowercase])
                    displayString += " поне една малка буква,";

                if (!strongPasswordConditionDictionary[Condition.containsUppercase])
                    displayString += " поне една голяма буква,";

                if (!strongPasswordConditionDictionary[Condition.containsSpecialCharacter])
                    displayString += " поне един символ различен от цифра и буква";
            }

            return displayString;
        }
    }
}
