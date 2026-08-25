using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                if (!string.IsNullOrEmpty(data) && data.Length > 10)
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
                if (!string.IsNullOrEmpty(data) && int.TryParse(data, out recurrenceType) && recurrenceType > 0 && recurrenceType <= typeLength)
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

        internal static DateOnly GetTargetDate()
        {
            int tries = 3;
            string? input;
            for (int i = 1; i <= tries; i++)
            {
                Console.Write($"Date (DD/MM/YYYY): ");
                input = Console.ReadLine();
                if (DateOnly.TryParse(input, out DateOnly date) && date > DateOnly.FromDateTime(DateTime.Now))
                {
                    return date;
                }
                else
                {
                    WriteColored($"Data entered is invalid\n{3 - i} Tries left", ConsoleColor.Red);
                }
            }

            WriteColored("Entered date is not valid, today's date is set as default", ConsoleColor.Yellow);
            return DateOnly.FromDateTime(DateTime.Now);
        }

        internal static string? GetTaskName()
        {
            int maxTries = 3;
            string? data;
            for (int i = 0; i < maxTries; i++)
            {
                Console.Write("Task Name: ");
                data = Console.ReadLine();
                if (!string.IsNullOrEmpty(data) && data.Length > 5)
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
            for(int i = 0; i < maxTries; i++)
            {
                Console.Write("User Id: ");
                data = Console.ReadLine();
                if(!string.IsNullOrEmpty(data))
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

        internal static string? GetUserName()
        {
            int maxTries = 3;
            string? data;
            for (int i = 0; i < maxTries; i++)
            {
                Console.Write("User Name: ");
                data = Console.ReadLine();
                if (!string.IsNullOrEmpty(data))
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
                Console.Write("Password: ");
                data = Console.ReadLine();
                if (!string.IsNullOrEmpty(data) && data.Length > 6)
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
