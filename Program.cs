using PhoneBook.StaticHelpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace PhoneBook
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ReadLine();
            PhoneBook phoneBook = new PhoneBook(@"..\\..\\..\\Samples\\FirstPhoneBook.txt");
            phoneBook.ShowPhoneBook();
            phoneBook.ShowErrors();
        }
    }
}
