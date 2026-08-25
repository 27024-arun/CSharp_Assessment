namespace ToDoApplication.Models
{
    /// <summary>
    /// Users class consists of the properties of User data.
    /// </summary>
    internal class User
    {
        /// <summary>
        /// Constructor for instantiation of the class User.
        /// </summary>
        public User()
        {
        }

        /// <summary>
        /// Constructor for instantiation of the class User.
        /// </summary>
        /// <param name="UserId">UserId is the unique id of the user.</param>
        /// <param name="UserName">UserName is the name of the user.</param>
        /// <param name="Password">Password is the secret credential of the password.</param>
        public User(string UserId, string UserName, string Password)
        {
            this.UserId = UserId;
            this.UserName = UserName;
            this.Password = Password;
        }

        /// <summary>
        /// UserId is the unique id of the user.
        /// </summary>
        public string UserId { get; set; } = string.Empty;

        /// <summary>
        /// UserName is the name of the user.
        /// </summary>
        public string UserName { get; set; } = string.Empty;

        /// <summary>
        /// Password is the secret credential of the password.
        /// </summary>
        public string Password { get; set; } = string.Empty;
    }
}
