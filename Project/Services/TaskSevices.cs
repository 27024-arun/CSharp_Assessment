using System.Threading.Tasks;
using ToDoApplication.Models;
using ToDoApplication.Repository;

namespace ToDoApplication.Services
{
    internal class TaskSevices
    {
        private readonly TaskRepository _taskRepository;

        public TaskSevices(TaskRepository taskRepository)
        {
            this._taskRepository = taskRepository;
        }

        internal bool AddTask(Tasks task)
        {
            if (!this._taskRepository.IsTaskAlreadyExists(task.OwnerId, task.TaskName))
            {
                this._taskRepository.AddTask(task);
                return true;
            }
            return false;
        }

        internal bool DeleteUserTask(string userId, string taskName)
        {
            if (!this._taskRepository.IsTaskAlreadyExists(userId, taskName))
            {
                return false;
            }
            Tasks? task = this._taskRepository.GetSpecificTask(userId, taskName);
            if (task is null)
            {
                return false;
            }
            return this._taskRepository.DeleteTask(task);
        }

        internal bool UpdateTask(string oldTaskName, Tasks task)
        {
            return this._taskRepository.UpdateUserTask(oldTaskName, task);
        }

        internal List<Tasks> GetAllUserTasks(string id)
        {
            return this._taskRepository.GetUserTasks(id);
        }

        internal bool IsTasksExists(string userId)
        {
            return this._taskRepository.IsUserTasksExists(userId);
        }

        internal bool IsTaskAlreadyExists(string userId, string taskName)
        {
            return this._taskRepository.IsTaskAlreadyExists(userId, taskName);
        }
    }
}
