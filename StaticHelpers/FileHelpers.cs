using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PhoneBook.StaticHelpers
{
    public static class FileHelpers
    {
        public static string Reader(string path)
        {
            string file = "";
            try
            {
                file = File.ReadAllText(path);
            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex.Message);
            }
            return file;
        }
    }
}
