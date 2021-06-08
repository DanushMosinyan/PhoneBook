using PhoneBook.StaticHelpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace PhoneBook
{
    static class Program
    {
        public static string path;
        static void Main(string[] args)
        {
            Console.ReadLine();
            path = @"..\\..\\..\\Samples\\FirstPhoneBook.txt";
            Runer.PhoneBook(path);
        }

       
    }
}
