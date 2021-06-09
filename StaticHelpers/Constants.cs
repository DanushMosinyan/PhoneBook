using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneBook.StaticHelpers
{
    public static class Constants
    {
        public const int PhoneNumberFormatLenght = 9;
        public static readonly string[] ValidSeparators = { "-", ":" };
        public const string InvalidSeparatorMessage = "separator should be : or -";
        public const string InvalidNumberMessage = "phone number should be with 9 digits";
    }
}
