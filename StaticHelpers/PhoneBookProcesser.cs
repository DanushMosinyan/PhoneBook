using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PhoneBook.StaticHelpers
{
    class PhoneBookProcesser
    {
        public static void GetPhoneBookFromFile(string path)
        {
            bool isNumberValid;
            List<string> numberErrors = new List<string>();
            List<string> separatorErrors = new List<string>();
            Console.WriteLine("PhoneBook Program:");
            string allText = FileHelpers.TextFromFileReader(path);
            Console.WriteLine(allText);
            List<Person> persons = Person.TextToPersonInfo(allText, separatorErrors);
            for (int index = 0; index < persons.Count; index++)
            {
                isNumberValid = true;
                if (!persons[index].Number.Validator())
                    isNumberValid = false;
                numberErrors.Add(isNumberValid ? null : StringHelpers.invalidNumberMessage);
            }
            ShowHelpers.ShowErrors( numberErrors, separatorErrors );
            Console.ReadLine();
        }
    }
}
