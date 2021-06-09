using PhoneBook.StaticHelpers;
using System.Collections.Generic;

namespace PhoneBook
{
    public class Person
    {
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
