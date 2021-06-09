using PhoneBook.StaticHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PhoneBook
{
    public class PhoneBook
    {
        private readonly string textFromFile;

        private Dictionary<int, string> errors = new Dictionary<int, string>();
        private List<Person> contacts;

        public PhoneBook(string path)
        {
            textFromFile = FileHelpers.TextReader(path);
            if (textFromFile == null)
            {
                Console.WriteLine("There is no text");
            }
            contacts = GetPhoneBookFromText(textFromFile);
            errors = GetSeporatorErrors(this.errors);
            errors = FindPhoneNumberValidationErrors(this.errors);
        }

        private List<Person> GetPhoneBookFromText(string Text)
        {
            return TextToPersonList(Text);
        }

        private Dictionary<int, string> FindPhoneNumberValidationErrors(Dictionary<int, string> errors)
        {
            for (int i = 0; i < contacts.Count; i++)
            {
                if (!contacts[i].Number.IsValidPhoneNumber())
                {
                    if (errors.ContainsKey(i))
                    {
                        errors[i] = StringHelpers.ErrorsCombiner(Constants.InvalidNumberMessage, errors[i]);
                    }
                    else
                    {
                        errors[i] = Constants.InvalidNumberMessage;
                    }
                }
            }
            return errors;
        }

        public void ShowPhoneBook()
        {
            Console.WriteLine("PhoneBook Program:");
            Console.WriteLine(textFromFile);
        }

        public void ShowErrors()
        {
            string errorMessage;
            foreach (var error in errors.OrderBy(obj => obj.Key))
            {
                errorMessage = $"line {error.Key + 1}: {error.Value}";
                Console.WriteLine(errorMessage);
            }
        }

        private Dictionary<int, string> GetSeporatorErrors(Dictionary<int, string> errors)
        {
            string separator;
            List<string> rows = textFromFile.TextToRowSpliter();
            for (int i = 0; i < rows.Count; i++)
            {
                string[] substring = rows[i].RowToWordSpliter();
                if (substring.Length == Constants.RowMembersCount)
                {
                    separator = substring[2];
                    if (!StringHelpers.IsValidSeparator(separator))
                        errors[i] = Constants.InvalidSeparatorMessage;
                }
                else if (substring.Length == Constants.RowMembersCountWithoutSurname)
                {
                    separator = substring[1];
                    if (!StringHelpers.IsValidSeparator(separator))
                        errors[i] = Constants.InvalidSeparatorMessage;
                }
            }
            return errors;
        }

        private List<Person> TextToPersonList(string Text)
        {
            string name;
            string surname;
            string number;
            List<Person> people = new List<Person>();
            List<string> rows = Text.TextToRowSpliter();
            for (int i = 0; i < rows.Count; i++)
            {
                string[] substring = rows[i].RowToWordSpliter();
                if (substring.Length == 1 && substring[0] == "")
                {
                    continue;
                }
                if (substring.Length == Constants.RowMembersCount)
                {
                    name = substring[0];
                    surname = substring[1];
                    number = substring[3];
                }
                else if (substring.Length == Constants.RowMembersCountWithoutSurname)
                {
                    name = substring[0];
                    surname = null;
                    number = substring[2];
                }
                else
                {
                    Console.WriteLine($"Wrong format in line {i + 1}");
                    continue;
                }
                people.Add(new Person(name, number, surname));
            }
            return people;
        }
    }
}
