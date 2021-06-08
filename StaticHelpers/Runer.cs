using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PhoneBook.StaticHelpers
{
    class Runer
    {

        public static void PhoneBook(string path)
        {
            Console.WriteLine("PhoneBook Program:");
            string allText = FileHelpers.Reader(path);
            Console.WriteLine(allText);
            List<Person> persons = Person.TextToPersonInfo(allText);
            foreach (var person in persons.Select((value, index) => new { value, index }))
            {
                if (!person.value.Number.Validator())
                    Console.WriteLine(StringHelpers.invalidNumberMessage + $" {person.index + 1}");
            }
            string[] Rows = allText.TextToRowSpliter();

            Console.ReadLine();
        }
    }
}
