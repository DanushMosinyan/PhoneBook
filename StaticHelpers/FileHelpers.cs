using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PhoneBook.StaticHelpers
{
    public static class FileHelpers
    {
        public static string TextFromFileReader(string path)
        {
            try
            {
                return File.ReadAllText(path);
            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex.Message);
            }
            return null;
        }
    }
}
