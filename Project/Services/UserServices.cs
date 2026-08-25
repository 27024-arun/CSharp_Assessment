using ToDoApplication.Models;
using ToDoApplication.Repository;

namespace ToDoApplication.Services
{
    internal class UserServices
    {
        private readonly UserRepository _userRepository;

        public UserServices(UserRepository userRepository)
        {
            this._userRepository = userRepository;
        }

        internal bool AddUser(string id, string name, string password)
        {
            if (!this._userRepository.IsUserAlreadyExists(id, password))
            {
                User user = new User(id, name, password);
                this._userRepository.Add(user);
                return true;
            }
            return false;
        }

        internal User? GetCurrentUser(string id, string password)
        {
            return this._userRepository.GetUser(id, password);
        }

        internal bool UserExists(string id, string password)
        {
            return this._userRepository.IsUserAlreadyExists(id, password);
        }
    }
}
