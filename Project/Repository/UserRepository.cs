using System.Text.Json;
using ToDoApplication.Models;

namespace ToDoApplication.Repository
{
    internal class UserRepository
    {
        private readonly List<User> _users = new List<User>();
        private readonly string _filePath;

        private readonly JsonSerializerOptions _options = new JsonSerializerOptions
        {
            WriteIndented = true,
        };
        public UserRepository(string filePath)
        {
            this._filePath = filePath;
            this._users = this.LoadAll();
        }

        /// <summary>
        /// Adds the user data to repository.
        /// </summary>
        /// <param name="user">User data</param>
        internal void Add(User user)
        {
            this._users.Add(user);
            this.WriteAll();
        }

        /// <summary>
        /// Checks whether the user already exists or not
        /// </summary>
        /// <param name="id">Unique identifier of the user.</param>
        /// <param name="password">Password of the user.</param>
        /// <returns>Returns true if any user already exists and false if not.</returns>
        internal bool IsUserAlreadyExists(string id, string password)
        {
            return this._users.Any(user => user.UserId == id && user.Password == password);
        }

        /// <summary>
        /// WriteAll method is used to Serialize data and store into file.
        /// </summary>
        private void WriteAll()
        {
            string fileData = JsonSerializer.Serialize(this._users, this._options);
            File.WriteAllText(this._filePath, fileData);
        }

        /// <summary>
        /// LoadAll method is used to retrieve data from file and load into in-memory.
        /// </summary>
        /// <returns></returns>
        private List<User> LoadAll()
        {
            if (!File.Exists(this._filePath))
            {
                return new List<User>();
            }

            string fileData = File.ReadAllText(this._filePath);
            return JsonSerializer.Deserialize<List<User>>(fileData, this._options) ?? new List<User>();
        }

        /// <summary>
        /// GetUser method is used to retrieve a particular with the matching credential.
        /// </summary>
        /// <param name="id">Unique identifier of the user.</param>
        /// <param name="password">Password of the user.</param>
        /// <returns>Returns the User data.</returns>
        internal User? GetUser(string id, string password)
        {
            return this._users.FirstOrDefault(user => user.UserId == id && user.Password == password);
        }
    }
}
