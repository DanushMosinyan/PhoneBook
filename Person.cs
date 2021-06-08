using PhoneBook.StaticHelpers;
using System.Collections.Generic;

namespace PhoneBook
{
    public class Person
    {
        public static List<Person> TextToPersonInfo(string text)
        {
            List<Person> people = new List<Person>();
            string[] rows = text.TextToRowSpliter();

            foreach (string row in rows)
            {
                string[] substring = row.RowToWordSpliter();
                if (substring.Length == 4)
                {
                    people.Add(new Person(name: substring[0], number: substring[3], surname: substring[1]));
                    if (!substring[2].SeporatorValidator())
                        System.Console.WriteLine(StringHelpers.invalidSeparatorMessage + $" {people.Count}");
                }
                if (substring.Length == 3)
                {
                    people.Add(new Person(name: substring[0], number: substring[2]));
                    if (!substring[1].SeporatorValidator())
                        System.Console.WriteLine(StringHelpers.invalidSeparatorMessage + $" {people.Count}");
                }
            }
            return people;
        }
        public Person(string name, string number, string surname = "Default")
        {
            this.Name = name;
            this.Number = number;
            this.Surname = surname;
        }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Number { get; set; }
    }
}
