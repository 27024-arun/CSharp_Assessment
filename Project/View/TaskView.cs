using ToDoApplication.Models;
using ToDoApplication.Services;

namespace ToDoApplication.View
{
    internal class TaskView
    {
        private User _currentUser;
        private TaskSevices taskService;

        public TaskView(TaskSevices taskService)
        {
            this.taskService = taskService;
            this._currentUser = new User();
        }
        public void AssignCurrentUser(User user)
        {
            this._currentUser = user;
        }
        public void TaskMenu()
        {
            while (true)
            {
                string taskMenu = $@"
=========TASK MENU=========
[A]dd Task
[E]dit Task
[D]elete Task
[V]iew Task
[R]etrun
Enter Choice: ";
                Console.Write(taskMenu);
                ConsoleKey userChoice = Console.ReadKey().Key;
                switch (userChoice)
                {
                    case ConsoleKey.A:
                        this.AddTask();
                        break;
                    case ConsoleKey.E:
                        this.EditTask();
                        break;
                    case ConsoleKey.D:
                        this.DeleteTask();
                        break;
                    case ConsoleKey.V:
                        this.ViewTask();
                        break;
                    case ConsoleKey.R:
                        this._currentUser = null;
                        ViewHelper.WriteColored($"\nReturning", ConsoleColor.Red);
                        Thread.Sleep(1300);
                        return;
                    default:
                        break;
                }
            }
        }

        private void AddTask()
        {
            
        }

        private void EditTask()
        {
            throw new NotImplementedException();
        }

        private void DeleteTask()
        {
            throw new NotImplementedException();
        }

        private void ViewTask()
        {
            throw new NotImplementedException();
        }
    }
}
