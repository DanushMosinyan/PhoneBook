using PhoneBook.StaticHelpers;
using System.Collections.Generic;

namespace PhoneBook
{
    public class Person
    {
        private const int membersCount = 4;
        private const int membersCountWithoutSurname = 3;
        public static List<Person> TextToPersonInfo(string text, Dictionary<int, string> errors)
        {
            string name;
            string surname;
            string separator;
            string number;
            List<Person> people = new List<Person>();
            string[] rows = text.TextToRowSpliter();
            for (int i = 0; i < rows.Length; i++)
            {
                string[] substring = rows[i].RowToWordSpliter();
                if (substring.Length == 1 && substring[0] == "")
                {
                    continue;
                }
                if (substring.Length == membersCount)
                {
                    name = substring[0];
                    surname = substring[1];
                    separator = substring[2];
                    number = substring[3];
                }
                else if (substring.Length == membersCountWithoutSurname)
                {
                    name = substring[0];
                    surname = null;
                    separator = substring[1];
                    number = substring[2];
                }
                else
                {
                    System.Console.WriteLine($"Wrong format in line {(i + 1) / 2}");
                    continue;
                }
                people.Add(new Person(name: name, number: number, surname: surname));
                if (!StringHelpers.SeparatorValidator(separator))
                    errors[((i + 1) / 2)] = StringHelpers.invalidSeparatorMessage;

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
