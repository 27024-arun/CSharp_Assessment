using ToDoApplication.Models;
using ToDoApplication.Services;

namespace ToDoApplication.View
{
    internal class TaskView
    {
        private User _currentUser;
        private TaskSevices _taskService;

        public TaskView(TaskSevices taskService)
        {
            this._taskService = taskService;
            this._currentUser = new User();
        }

        public void AssignCurrentUser(User user)
        {
            this._currentUser = user;
        }

        public void PrintCurrentUser()
        {
            string currentUser = $@"
=============================
User Name: {this._currentUser.UserName}
=============================";
            Console.WriteLine(currentUser);
        }

        public void TaskMenu()
        {
            while (true)
            {
                this.PrintCurrentUser();
                string taskMenu = $@"
=========TASK MENU=========
[A]dd Task
[E]dit Task
[D]elete Task
[V]iew Task
[R]eturn
Enter Choice: ";
                Console.Write(taskMenu);
                ConsoleKey userChoice = Console.ReadKey().Key;
                switch (userChoice)
                {
                    case ConsoleKey.A:
                        Console.Clear();
                        this.AddTask();
                        break;
                    case ConsoleKey.E:
                        Console.Clear();
                        this.EditTask();
                        break;
                    case ConsoleKey.D:
                        Console.Clear();
                        this.DeleteTask();
                        break;
                    case ConsoleKey.V:
                        Console.Clear();
                        this.ViewTask();
                        break;
                    case ConsoleKey.R:
                        this._currentUser = new User();
                        ViewHelper.WriteColored($"\nReturning", ConsoleColor.Red);
                        Thread.Sleep(1300);
                        Console.Clear();
                        return;
                    default:
                        break;
                }
            }
        }

        private void AddTask()
        {
            Console.WriteLine();
            string? taskName = ViewHelper.GetTaskName("Task Name");
            if(taskName is null)
            {
                return;
            }
            string? description = ViewHelper.GetDescription();
            if(description is null)
            {
                return;
            }
            DateOnly targetDate = ViewHelper.GetTargetDate();
            foreach(var type in Enum.GetValues(typeof(RecurrenceType)))
            {
                Console.WriteLine($"{(int)type}. {type}");
            }
            int recurrenceType = ViewHelper.GetRecurrenceType(Enum.GetValues(typeof(RecurrenceType)).Length);
            if(recurrenceType == 0)
            {
                return;
            }
            if (this._taskService.AddTask(new Tasks(this._currentUser.UserId, taskName, description, targetDate, (RecurrenceType)recurrenceType)))
            {
                ViewHelper.WriteColored("Task is added", ConsoleColor.Green);
            }
            else
            {
                ViewHelper.WriteColored("Task already exists", ConsoleColor.Red);
            }
        }

        private void EditTask()
        {
            if (!this._taskService.IsTasksExists(this._currentUser.UserId))
            {
                ViewHelper.WriteColored($"No tasks exists.", ConsoleColor.Red);
                ViewHelper.WriteColored($"Enter any key to return", ConsoleColor.Yellow);
                Console.ReadKey();
                Console.Clear();
                return;
            }
            string? oldTaskName = ViewHelper.GetTaskName("Old Task Name");
            if (oldTaskName is null)
            {
                return;
            }
            if(!this._taskService.IsTaskAlreadyExists(this._currentUser.UserId, oldTaskName))
            {
                ViewHelper.WriteColored("Task doesn't exist", ConsoleColor.Red);
                return;
            }

            string? newTaskName = ViewHelper.GetTaskName("New Task Name");
            if (newTaskName is null)
            {
                return;
            }
            string? description = ViewHelper.GetDescription();
            if (description is null)
            {
                return;
            }
            DateOnly targetDate = ViewHelper.GetTargetDate();
            foreach (var type in Enum.GetValues(typeof(RecurrenceType)))
            {
                Console.WriteLine($"{(int)type}. {type}");
            }
            int recurrenceType = ViewHelper.GetRecurrenceType(Enum.GetValues(typeof(RecurrenceType)).Length);
            if (recurrenceType == 0)
            {
                return;
            }
            Tasks task = new Tasks(this._currentUser.UserId, newTaskName, description, targetDate, (RecurrenceType)recurrenceType);
            if (this._taskService.UpdateTask(oldTaskName, task))
            {
                ViewHelper.WriteColored("Task is updated", ConsoleColor.Green);
            }
            else
            {
                ViewHelper.WriteColored("Task not updated", ConsoleColor.Red);
            }
        }

        private void DeleteTask()
        {
            if (!this._taskService.IsTasksExists(this._currentUser.UserId))
            {
                ViewHelper.WriteColored($"No tasks exists.", ConsoleColor.Red);
                ViewHelper.WriteColored($"Enter any key to return", ConsoleColor.Yellow);
                Console.ReadKey();
                Console.Clear();
                return;
            }

            string? taskName = ViewHelper.GetTaskName("Task Name");
            if (taskName is null)
            {
                return;
            }

            if(this._taskService.DeleteUserTask(this._currentUser.UserId, taskName))
            {
                ViewHelper.WriteColored($"Task is deleted", ConsoleColor.Green);
            }
            else
            {
                ViewHelper.WriteColored($"Task is not deleted", ConsoleColor.Red);
            }
            ViewHelper.WriteColored($"Enter any key to return", ConsoleColor.Yellow);
            Console.ReadKey();
            Console.Clear();
        }

        private void ViewTask()
        {
            if (this._taskService.IsTasksExists(this._currentUser.UserId))
            {
                List<Tasks> tasks = this._taskService.GetAllUserTasks(this._currentUser.UserId);
                foreach (Tasks task in tasks)
                {
                    Console.WriteLine();
                    Console.WriteLine($"\nName: {task.TaskName}\nDescription: {task.Description}\nTarget Date: {task.TargetDate}\nTask Recurrence: {task.TaskRecurrence}");
                }
            }
            else
            {
                ViewHelper.WriteColored($"No tasks exists.", ConsoleColor.Red);
            }
            ViewHelper.WriteColored($"Enter any key to return", ConsoleColor.Yellow);
            Console.ReadKey();
            Console.Clear();
        }
    }
}
