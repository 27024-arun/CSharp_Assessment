using ToDoApplication.Repository;
using ToDoApplication.Models;

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

        internal List<Tasks> GetAllUserTasks(string id)
        {
            return this._taskRepository.GetUserTasks(id);
        }

        internal bool IsTasksExists(string userId)
        {
            return this._taskRepository.IsUserTasksExists(userId);
        }
    }
}
