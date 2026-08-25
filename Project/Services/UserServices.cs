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

        /// <summary>
        /// Checks for existing data and passes the User data to repository for addition.
        /// </summary>
        /// <param name="id">Unique identifier of the user</param>
        /// <param name="name">Name of the user</param>
        /// <param name="password">Password of the user</param>
        /// <returns>Returns whether the user is added or not.</returns>
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

        /// <summary>
        /// GetCurrentUser method is used to retrieve the data of the user based on his credentials.
        /// </summary>
        /// <param name="id">Unique identifier of the user</param>
        /// <param name="password">Password of the user</param>
        /// <returns>Returns the user with the matching credential.</returns>
        internal User? GetCurrentUser(string id, string password)
        {
            return this._userRepository.GetUser(id, password);
        }

        /// <summary>
        /// Checks whether the user exists or not.
        /// </summary>
        /// <param name="id">Unique identifier of the user</param>
        /// <param name="password">Password of the user</param>
        /// <returns>Returns whether the user already exists or not.</returns>
        internal bool UserExists(string id, string password)
        {
            return this._userRepository.IsUserAlreadyExists(id, password);
        }
    }
}
