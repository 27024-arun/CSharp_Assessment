using ToDoApplication.Repository;
using ToDoApplication.Services;
using ToDoApplication.View;

namespace ToDoApplication
{
    /// <summary>
    /// Program is the entry level class.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Main method is the entry point of the program.
        /// </summary>
        public static void Main()
        {
            TaskRepository taskRepository = new TaskRepository("Tasks.json");
            UserRepository userRepository = new UserRepository("Users.json");

            TaskSevices taskService = new TaskSevices(taskRepository);
            UserServices userServices = new UserServices(userRepository);

            TaskView taskView = new TaskView(taskService);
            UserView userView = new UserView(userServices, taskView);

            while (true)
            {
                try
                {
                    string mainMenu = $@"
=========MAIN MENU=========
[S]ignUp
[L]ogIn
[E]xit
Enter Choice: ";
                    Console.Write(mainMenu);
                    ConsoleKey userChoice = Console.ReadKey().Key;
                    switch (userChoice)
                    {
                        case ConsoleKey.S:
                            userView.SignUp();
                            break;
                        case ConsoleKey.L:
                            userView.LogIn();
                            break;
                        case ConsoleKey.E:
                            ViewHelper.WriteColored($"\nExiting", ConsoleColor.Red);
                            Thread.Sleep(1300);
                            return;
                        default:
                            Console.Clear();
                            break;
                    }
                }
                catch (Exception e)
                {
                    ViewHelper.WriteColored($"\n{e.Message}", ConsoleColor.Red);
                }
            }
        }
    }
}
