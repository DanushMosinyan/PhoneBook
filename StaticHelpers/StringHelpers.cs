using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;

namespace PhoneBook.StaticHelpers
{
    public static class StringHelpers
    {
        private static int formatLenght = 9;
        public static bool Validator(this string str)
        {
            string myString = str;
            bool flag = true;
            int i = 0;
            int j = 0;
            try
            {
                while (flag && formatLenght > i)
                {
                    flag = Int32.TryParse(myString[j].ToString(), out _);
                    i++;
                    j++;
                }
                if (myString.Length - j != 0)
                {
                    return false;
                }
            }
            catch (IndexOutOfRangeException)
            {
                return false;
            }
            return flag;
        }
        private static string[] validSeparators = new string[] { "-", ":" };
        public const string invalidSeparatorMessage = "separator should be : or -";
        public const string invalidNumberMessage = "phone number should be with 9 digits";
        public static bool SeparatorValidator(this string seporator)
        {
            return validSeparators.Contains(seporator);
        }
        public static string[] TextToRowSpliter(this string str)
        {
            return str.Split('\r', '\n');
        }
        public static string[] RowToWordSpliter(this string str)
        {
            return str.Split(' ');
        }
    }
}
