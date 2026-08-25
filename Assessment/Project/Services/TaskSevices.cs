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
    }
}
