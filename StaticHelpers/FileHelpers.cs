using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PhoneBook.StaticHelpers
{
    public static class FileHelpers
    {
        public static string TextReader(string path)
        {
            try
            {
                return File.ReadAllText(path);
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch(FileLoadException ex)
            {
                Console.WriteLine(ex.Message);
            }
            
            return null;
        }
    }
}
