using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;

namespace PhoneBook.StaticHelpers
{
    public static class StringHelpers
    {
        private const int formatLenght = 9;
        public static bool Validator(this string str)
        {
            bool isValid = true;
            int lastIndex = 0;
            try
            {
                while (isValid && formatLenght > lastIndex)
                {
                    isValid = int.TryParse(str[lastIndex].ToString(), out _);
                    lastIndex++;
                }
                if (str.Length - lastIndex != 0)
                {
                    return false;
                }
            }
            catch (IndexOutOfRangeException)
            {
                return false;
            }
            return isValid;
        }

        private static string[] validSeparators = new string[] { "-", ":" };
        public const string invalidSeparatorMessage = "separator should be : or -";
        public const string invalidNumberMessage = "phone number should be with 9 digits";

        public static bool SeparatorValidator(string seporator)
        {
            return validSeparators.Contains(seporator);
        }
        public static string[] TextToRowSpliter(this string str)
        {
            return str.Split('\n', '\r');
        }
        public static string[] RowToWordSpliter(this string str)
        {
            return str.Split(' ');
        }
        public static string ErrorsCombiner(string first, string second)
        {
            string combined;
            if (string.IsNullOrEmpty(first) && string.IsNullOrEmpty(second))
            {
                combined = null;
            }
            else if (!string.IsNullOrEmpty(first))
            {
                combined = StringHelpers.invalidNumberMessage;
                if (!string.IsNullOrEmpty(second))
                {
                    combined = combined + ", " + StringHelpers.invalidSeparatorMessage;
                }
            }
            else
            {
                combined = StringHelpers.invalidSeparatorMessage;
            }
            return combined;
        }
    }
}
