using System.Text.Json;
using System.Text.Json.Serialization;
using ToDoApplication.Models;
using ToDoApplication.Repository.Utility;

namespace ToDoApplication.Repository
{
    internal class TaskRepository
    {
        private readonly List<Tasks> _tasks = new List<Tasks>();

        private readonly string _filePath;

        private readonly JsonSerializerOptions _options = new JsonSerializerOptions
        {
            WriteIndented = true,
            Converters =
            {
                new JsonStringEnumConverter(),
                new JsonDateOnlyConverter(),
            }
        };
        public TaskRepository(string filePath)
        {
            this._filePath = filePath;
            this._tasks = this.LoadAll();
        }

        internal void AddTask(Tasks task)
        {
            this._tasks.Add(task);
            this.WriteAll();
        }

        internal bool IsTaskAlreadyExists(string id, string taskName)
        {
            return this._tasks.Any(task => task.OwnerId == id && task.TaskName == taskName);
        }

        internal bool IsUserTasksExists(string userId)
        {
            if (!File.Exists(this._filePath))
            {
                return false;
            }
            return this._tasks.Any(task => task.OwnerId == userId);
        }

        internal List<Tasks> GetUserTasks(string id)
        {
            return this._tasks.Where(task => task.OwnerId == id).ToList();
        }

        private void WriteAll()
        {
            string fileData = JsonSerializer.Serialize(this._tasks, this._options);
            File.WriteAllText(this._filePath, fileData);
        }

        private List<Tasks> LoadAll()
        {
            if (!File.Exists(this._filePath))
            {
                return new List<Tasks>();
            }

            string fileData = File.ReadAllText(this._filePath);
            return JsonSerializer.Deserialize<List<Tasks>>(fileData, this._options) ?? new List<Tasks>();
        }
    }
}
