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

        internal static string? GetUserId()
        {
            int maxTries = 3;
            string? data;
            for(int i = 0; i < maxTries; i++)
            {
                Console.WriteLine("User Id: ");
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
                Console.WriteLine("User Name: ");
                data = Console.ReadLine();
                if (!string.IsNullOrEmpty(data))
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

        internal static string? GetUserPassword()
        {
            int maxTries = 3;
            string? data;
            for (int i = 0; i < maxTries; i++)
            {
                Console.WriteLine("Password: ");
                data = Console.ReadLine();
                if (!string.IsNullOrEmpty(data))
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
    }
}
