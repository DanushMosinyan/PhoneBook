using PhoneBook.StaticHelpers;
using System.Collections.Generic;

namespace PhoneBook
{
    public class Person
    {
        private const int rowCountWithSurname = 4;
        private const int rowCountWithoutSurname = 3;
        public static List<Person> TextToPersonInfo(string text, List<string> separatorErrors)
        {
            bool isValidSeporator;
            List<Person> people = new List<Person>();
            string[] rows = text.TextToRowSpliter();
            for (int i = 0; i < rows.Length; i++)
            {
                isValidSeporator = true;
                string[] substring = rows[i].RowToWordSpliter();
                if (substring.Length == rowCountWithSurname)
                {
                    people.Add(new Person(name: substring[0], number: substring[3], surname: substring[1]));
                    if (!substring[2].SeparatorValidator())
                        isValidSeporator = false;
                    separatorErrors.Add(isValidSeporator ? null : StringHelpers.invalidSeparatorMessage);
                }
                if (substring.Length == rowCountWithoutSurname)
                {
                    people.Add(new Person(name: substring[0], number: substring[2]));
                    if (!substring[1].SeparatorValidator())
                        isValidSeporator = false;
                    separatorErrors.Add(isValidSeporator ? null : StringHelpers.invalidSeparatorMessage);
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
