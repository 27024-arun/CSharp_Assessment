using ToDoApplication.Services;

namespace ToDoApplication.View
{
    internal class UserView
    {
        private UserServices _userServices;

        public UserView(UserServices userServices)
        {
            this._userServices = userServices;
        }
        internal void SignUp()
        {
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
            }
        }
    }
}
