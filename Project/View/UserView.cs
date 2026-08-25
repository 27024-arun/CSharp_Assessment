using ToDoApplication.Services;

namespace ToDoApplication.View
{
    internal class UserView
    {
        private UserServices _userServices;
        private TaskView _taskView;
        public UserView(UserServices userServices, TaskView taskView)
        {
            this._userServices = userServices;
            this._taskView = taskView;
        }
        internal void SignUp()
        {
            Console.Clear();
            Console.WriteLine("=========SINGUP MENU=========");
            string? id = ViewHelper.GetUserId();
            if(id is null)
            {
                return;
            }
            string? name = ViewHelper.GetUserName();
            if(name is null)
            {
                return;
            }
            string? password = ViewHelper.GetUserPassword();
            if(password is null)
            {
                return;
            }
            if(this._userServices.AddUser(id, name, password))
            {
                ViewHelper.WriteColored($"User account created", ConsoleColor.Green);
            }
        }

        internal void LogIn()
        {
            Console.Clear();
            Console.WriteLine("=========LOGIN MENU=========");
            string? id = ViewHelper.GetUserId();
            if (id is null)
            {
                return;
            }
            string? password = ViewHelper.GetUserPassword();
            if (password is null)
            {
                return;
            }
            if(this._userServices.UserExists(id, password))
            {
                ViewHelper.WriteColored("Logged In", ConsoleColor.Green);
                var user = this._userServices.GetCurrentUser(id, password);
                if(user != null)
                {
                    this._taskView.AssignCurrentUser(user);
                    Console.Clear();
                    this._taskView.TaskMenu();
                }
            }
            else
            {
                ViewHelper.WriteColored($"User data not valid\nReturning to Main menu.", ConsoleColor.Red);
                Thread.Sleep(1300);
                Console.Clear();
            }
        }
    }
}
