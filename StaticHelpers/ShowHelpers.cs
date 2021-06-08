using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneBook.StaticHelpers
{
    public static class ShowHelpers
    {
        public static void ShowErrors(List<string> numberErrors, List<string> separatorErrors)
        {
            string errorMessage;
            for (int i = 0; i < numberErrors.Count; i++)
            {
                if (!(!(string.IsNullOrEmpty(numberErrors[i])) || !(string.IsNullOrEmpty(separatorErrors[i]))))
                {
                    continue;
                }
                errorMessage = $"Line {i + 1} ";
                if (!string.IsNullOrEmpty(numberErrors[i]))
                {
                    errorMessage = errorMessage + StringHelpers.invalidNumberMessage;
                    if (!string.IsNullOrEmpty(separatorErrors[i]))
                    {
                        errorMessage = errorMessage + " , " + StringHelpers.invalidSeparatorMessage;
                    }
                }
                else if (!string.IsNullOrEmpty(separatorErrors[i]))
                {
                    errorMessage = errorMessage + StringHelpers.invalidSeparatorMessage;
                }
                Console.WriteLine(errorMessage);
            }
        }
    }
}
