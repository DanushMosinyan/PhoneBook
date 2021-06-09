using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PhoneBook.StaticHelpers
{
    class PhoneBookProcessor
    {
        public static void GetPhoneBookFromFile(string path)
        {
            Dictionary<int, string> errors = new Dictionary<int, string>();
            Console.WriteLine("PhoneBook Program:");
            string allText = FileHelpers.TextReader(path);
            Console.WriteLine(allText);
            List<Person> persons = Person.TextToPersonInfo(allText, errors);
            for (int i = 0; i < persons.Count; i++)
            {
                if (!persons[i].Number.Validator())
                    errors[i] = StringHelpers.ErrorsCombiner(StringHelpers.invalidNumberMessage, errors.ContainsKey(i) ? errors[i] : null);
            }
            ShowHelpers.ShowErrors(errors);
            Console.ReadLine();
        }
    }
}
