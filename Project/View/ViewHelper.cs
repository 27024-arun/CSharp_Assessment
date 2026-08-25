namespace ToDoApplication.View
{
    internal class ViewHelper
    {
        public static void WriteColored(string message, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        internal static string? GetDescription()
        {
            int maxTries = 3;
            string? data;
            for (int i = 0; i < maxTries; i++)
            {
                Console.Write("Description: ");
                data = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(data) && data.Length > 10)
                {
                    return data;
                }
                else
                {
                    ViewHelper.WriteColored($"Invalid Description [Add more details]\n{maxTries - i - 1} Tries left", ConsoleColor.Red);
                }
            }
            return null;
        }

        internal static int GetRecurrenceType(int typeLength)
        {
            int maxTries = 3;
            string? data;
            int recurrenceType;
            for (int i = 0; i < maxTries; i++)
            {
                Console.Write("Recurrence Type: ");
                data = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(data) && int.TryParse(data, out recurrenceType) && recurrenceType > 0 && recurrenceType <= typeLength)
                {
                    return recurrenceType;
                }
                else
                {
                    ViewHelper.WriteColored($"Invalid Recurrence Type\n{maxTries - i - 1} Tries left", ConsoleColor.Red);
                }
            }
            return 0;
        }

        internal static DateOnly GetTargetDate(string message)
        {
            int maxTries = 3;
            string? input;
            for (int i = 0; i < maxTries; i++)
            {
                Console.Write($"{message} (DD/MM/YYYY): ");
                input = Console.ReadLine();
                if (DateOnly.TryParse(input, out DateOnly date) && date >= DateOnly.FromDateTime(DateTime.Now))
                {
                    return date;
                }
                else
                {
                    WriteColored($"Entered date is invalid(DD/MM/YYYY)\n{maxTries - i - 1} Tries left", ConsoleColor.Red);
                }
            }

            WriteColored("Entered date is not valid, today's date is set as default", ConsoleColor.Yellow);
            return DateOnly.FromDateTime(DateTime.Today);
        }

        internal static string? GetTaskName(string message)
        {
            int maxTries = 3;
            string? data;
            for (int i = 0; i < maxTries; i++)
            {
                Console.Write($"{message}: ");
                data = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(data) && data.Length > 5)
                {
                    return data;
                }
                else
                {
                    ViewHelper.WriteColored($"Invalid Task Name\n{maxTries - i - 1} Tries left", ConsoleColor.Red);
                }
            }
            return null;
        }

        internal static string? GetUserId()
        {
            int maxTries = 3;
            string? data;
            for (int i = 0; i < maxTries; i++)
            {
                Console.Write("User Id [AlphaNumeric]: ");
                data = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(data) && data.Length > 4 && IsAlphaNumeric(data))
                {
                    return data;
                }
                else
                {
                    ViewHelper.WriteColored($"Invalid User id [Eg: PET1000]\n{maxTries - i - 1} Tries left", ConsoleColor.Red);
                }
            }
            return null;
        }

        private static bool IsAlphaNumeric(string data)
        {
            int hasDigit = 0;
            int hasCharacter = 0;
            foreach (char c in data)
            {
                if (char.IsDigit(c))
                {
                    hasDigit += 1;
                }
                if(char.IsLetter(c))
                {
                    hasCharacter += 1;
                }
            }
            return hasDigit > 0 && hasCharacter > 0;
        }

        internal static string? GetUserName()
        {
            int maxTries = 3;
            string? data;
            for (int i = 0; i < maxTries; i++)
            {
                Console.Write("User Name: ");
                data = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(data) && data.Length > 3)
                {
                    return data;
                }
                else
                {
                    ViewHelper.WriteColored($"Invalid User Name [Eg: Peter]\n{maxTries - i - 1} Tries left", ConsoleColor.Red);
                }
            }
            return null;
        }

        internal static string? GetUserPassword()
        {
            int maxTries = 3;
            string? data;
            for (int i = 0; i < maxTries; i++)
            {
                Console.Write("Password[AlphaNumeric]: ");
                data = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(data) && data.Length > 6 && IsAlphaNumeric(data))
                {
                    return data;
                }
                else
                {
                    ViewHelper.WriteColored($"Invalid User Password [Password length should be 6 characters]\n{maxTries - i - 1} Tries left", ConsoleColor.Red);
                }
            }
            return null;
        }
    }
}
