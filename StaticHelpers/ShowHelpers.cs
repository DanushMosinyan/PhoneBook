using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PhoneBook.StaticHelpers
{
    public static class ShowHelpers
    {
        public static void ShowErrors(Dictionary<int, string> errors)
        {
            string errorMessage;
            foreach (var error in errors.OrderBy(obj => obj.Key).ToDictionary(obj => obj.Key, obj => obj.Value))
            {
                if (!string.IsNullOrEmpty(error.Value))
                {
                    errorMessage = $"line {error.Key + 1}: " + error.Value;
                    Console.WriteLine(errorMessage);
                }
            }
        }

    }
}
