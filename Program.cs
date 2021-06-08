using PhoneBook.StaticHelpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PhoneBook
{
    static class Program
    {
        private static string formatStrig = "NNNNNNNNN";
        public static string path;
        static void Main(string[] args)
        {
            Console.ReadLine();
            Runer();
        }

        private static void Runer()
        {
            bool flag = true;
            while (flag)
            {
                Console.WriteLine("PhoneBook Program:");
                Console.WriteLine();
                path = @"..\\..\\..\\Samples\\FirstPhoneBook.txt";
                string info = FileHelpers.Reader(path);
                Console.WriteLine(info);
                string[] sub = info.Split(' ', '\r', '\n');
                int j = 0;
                int count = 0;
                List<PersonInfo> persons = new List<PersonInfo>();
                for (int i = 0; i < sub.Length; i++)
                {
                    if (sub[i] == "" || i == sub.Length - 1)
                    {
                        if (i - j == 4 || (i == sub.Length - 1 && i - j == 3))
                        {
                            persons.Add(new PersonInfo());
                            persons[count].Name = sub[j];
                            persons[count].Surname = sub[j + 1];
                            persons[count].Number = sub[j + 3];
                            if (!(sub[j + 2] == ":" || sub[j + 2] == "-"))
                                Console.WriteLine($"Wrong seporator format in line {count + 1}");
                            if (!sub[j + 3].Validator(formatStrig))
                                Console.WriteLine($"Wrong phone number format in line {count + 1}");

                        }
                        else if (i - j == 3 || (i == sub.Length - 1 && i - j == 2))
                        {
                            persons.Add(new PersonInfo());
                            persons[count].Name = sub[j];
                            persons[count].Number = sub[j + 2];
                            if (!(sub[j + 1] == ":" || sub[j + 1] == "-"))
                                Console.WriteLine($"Wrong seporator format in line {count + 1}");
                            if (!sub[j + 2].Validator(formatStrig))
                                Console.WriteLine($"Wrong phone number format in line {count + 1}");
                        }
                        else
                        {
                            throw new Exception($"Wrong format of phone book in line {count + 1}");
                        }
                        j = i + 1;
                        count++;
                    }
                }
                Console.ReadLine();
            }
        }
    }
}
