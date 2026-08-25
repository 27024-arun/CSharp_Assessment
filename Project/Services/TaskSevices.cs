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
            if (!this._taskRepository.IsTaskExists(task.OwnerId, task.TaskName))
            {
                this._taskRepository.AddTask(task);
                return true;
            }
            return false;
        }
    }
}
