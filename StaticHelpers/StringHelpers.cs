using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;

namespace PhoneBook.StaticHelpers
{
    public static class StringHelpers
    {
        public static bool IsValidPhoneNumber(this string str)
        {
            bool isValid = true;
            int lastIndex = 0;
            try
            {
                while (isValid && Constants.PhoneNumberFormatLenght > lastIndex)
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


        public static bool IsValidSeparator(string seporator)
        {
            return Constants.ValidSeparators.Contains(seporator);
        }
        public static List<string> TextToRowSpliter(this string str)
        {
            List<string> rows = new List<string>();
            foreach(var row in str.Split('\n', '\r'))
            {
                if (row.Length == 0 && row == "")
                {
                    continue;
                }
                else
                {
                    rows.Add(row);
                }
            }
            return rows;
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
                combined = Constants.InvalidNumberMessage;
                if (!string.IsNullOrEmpty(second))
                {
                    combined = combined + ", " + Constants.InvalidSeparatorMessage;
                }
            }
            else
            {
                combined = Constants.InvalidSeparatorMessage;
            }
            return combined;
        }
    }
}
