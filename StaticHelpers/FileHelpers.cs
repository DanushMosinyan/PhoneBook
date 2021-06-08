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
                using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
                {
                    StringBuilder stringBuilder = new StringBuilder();
                    byte[] bytes = new byte[fs.Length];
                    int numBytesToRead = (int)fs.Length;
                    int numBytesRead = 0;
                    while (numBytesToRead > 0)
                    {
                        int n = fs.Read(bytes, numBytesRead, numBytesToRead);

                        if (n == 0)
                            break;

                        numBytesRead += n;
                        numBytesToRead -= n;
                    }
                    foreach (byte b in bytes)
                    {
                        stringBuilder.Append(Convert.ToChar(b));
                    }
                    file = stringBuilder.ToString();
                }
            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex.Message);
            }
            return file;
        }
    }
}
