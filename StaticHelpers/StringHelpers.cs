using System;
using System.Collections.Generic;
using System.Reflection.Metadata;

namespace PhoneBook.StaticHelpers
{
    public static class StringHelpers
    {

        /*"N"---------- number
          "C"---------- char
          "(''||'')"--- Or              In dev
         */

        public static bool Validator(this string str, string format)
        {
            string myString = str;
            int formatLenght = format.Length;
            bool flag = true;
            int i = 0;
            int j = 0;
            try
            {
                while (flag && formatLenght > i)
                {
                    switch (format[i])
                    {
                        case 'N':
                            flag = Int32.TryParse(myString[j].ToString(), out _);
                            i++;
                            j++;
                            break;
                        case 'C':
                            flag = !Int32.TryParse(myString[j].ToString(), out _);
                            i++;
                            j++;
                            break;
                        #region Over Engineering
                        //case '2':
                        //    if (format[i + 1].ToString() == @"\")
                        //    {
                        //        flag = format[i] == myString[j];
                        //    }
                        //    i += 2;
                        //    j++;
                        //    break;
                        //case '(':
                        //    {
                        //        int count = 0;
                        //        for (int c = 0; c < format.Length - i; c++)
                        //        {
                        //            if (format[c] == '2')
                        //            {
                        //                count++;
                        //            }
                        //            if (format[c] == '|' || format[c] == ')')
                        //            {
                        //                string strModule = myString.Substring(j, c);
                        //                string formatModule = format.Substring(i, c);
                        //                i = i + c + count + format[c] == ')' ? 0 : 1;
                        //                j = j + c - 1;
                        //                flag = strModule.Validator(formatModule);
                        //            }

                        //            if (flag == true|| format[c] == ')')
                        //                break;
                        //        }

                        //        break;
                        //    }
                        #endregion
                        default:
                            if (format[i] == myString[j])
                            {
                                i++;
                                j++;
                                break;
                            }
                            return false;

                    }
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
        private static string[] validSeporators = new string[] { "-", ":", "--" };
        public const string invalidSeparatorMessage = "Invalid seporator in line";
        public const string invalidNumberMessage = "Invalid number in line";
        public static bool SeporatorValidator(this string seporator)
        {
            foreach (var validSeporator in validSeporators)
            {
                if (validSeporator == seporator)
                    return true;
            }
            return false;
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
