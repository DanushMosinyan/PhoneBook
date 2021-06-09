using PhoneBook.StaticHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PhoneBook
{
    public class PhoneBook
    {
        private const int MembersCount = 4;
        private const int MembersCountWithoutSurname = 3;
        private readonly string TextFromFile;

        private Dictionary<int, string> errors = new Dictionary<int, string>();
        private List<Person> phoneBook;

        public PhoneBook(string path)
        {
            TextFromFile = FileHelpers.TextReader(path);
            if (TextFromFile == null)
            {
                Console.WriteLine("There is no text");
            }
            GetPhoneBookFromText();
            FindPhoneNumberValidationErrors();
        }

        private void GetPhoneBookFromText()
        {
            phoneBook = this.TextToPersonList();
        }

        private void FindPhoneNumberValidationErrors()
        {
            for (int i = 0; i < phoneBook.Count; i++)
            {
                if (!phoneBook[i].Number.IsValidPhoneNumber())
                {
                    if(errors.ContainsKey(i))
                    {
                        errors[i] = StringHelpers.ErrorsCombiner(Constants.InvalidNumberMessage, errors[i]);
                    }
                    else
                    {
                        errors[i] = Constants.InvalidNumberMessage;
                    }
                }
            }
        }

        public void ShowPhoneBook()
        {
            Console.WriteLine("PhoneBook Program:");
            Console.WriteLine(TextFromFile);
        }

        public void ShowErrors()
        {
            string errorMessage;
            foreach (var error in errors.OrderBy(obj => obj.Key))
            {
                if (!string.IsNullOrEmpty(error.Value))
                {
                    errorMessage = $"line {error.Key + 1}: {error.Value}";
                    Console.WriteLine(errorMessage);
                }
            }
        }

        private List<Person> TextToPersonList()
        {
            string name;
            string surname;
            string separator;
            string number;
            List<Person> people = new List<Person>();
            List<string> rows = TextFromFile.TextToRowSpliter();
            for (int i = 0; i < rows.Count; i++)
            {
                string[] substring = rows[i].RowToWordSpliter();
                if (substring.Length == 1 && substring[0] == "")
                {
                    continue;
                }
                if (substring.Length == MembersCount)
                {
                    name = substring[0];
                    surname = substring[1];
                    separator = substring[2];
                    number = substring[3];
                }
                else if (substring.Length == MembersCountWithoutSurname)
                {
                    name = substring[0];
                    surname = null;
                    separator = substring[1];
                    number = substring[2];
                }
                else
                {
                    Console.WriteLine($"Wrong format in line {i + 1}");
                    continue;
                }
                people.Add(new Person(name, number, surname));
                if (!StringHelpers.IsValidSeparator(separator))
                    errors[i] = Constants.InvalidSeparatorMessage;

            }
            return people;
        }
    }
}
