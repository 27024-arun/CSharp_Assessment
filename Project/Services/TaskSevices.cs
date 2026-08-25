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

        /// <summary>
        /// Checks whether task already exists and passes to repository for addition of task.
        /// </summary>
        /// <param name="task">Task is the data of a particular task.</param>
        /// <returns>Returns whether the task is added or not.</returns>
        internal bool AddTask(Tasks task)
        {
            if (!this._taskRepository.IsTaskAlreadyExists(task.OwnerId, task.TaskName))
            {
                this._taskRepository.AddTask(task);
                return true;
            }
            return false;
        }

        /// <summary>
        /// DeleteUserTask is used to check whether the data exists and deletes the data.
        /// </summary>
        /// <param name="userId">userId is the current user Id.</param>
        /// <param name="taskName">TaskName is the name of the task which needs to be deleted.</param>
        /// <returns>Returns whether the task is deleted or not.</returns>
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

        /// <summary>
        /// UpdateTask method checks whether the data exists in repository and updated the repository.
        /// </summary>
        /// <param name="oldTaskName">oldTaskName is the name of the task which needs to be modified.</param>
        /// <param name="task">Task is data of a particular task.</param>
        /// <returns>Returns whether the data is updated or not.</returns>
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

        internal List<Tasks> GetTopTasks(string id)
        {
            List<Tasks> tasks = this._taskRepository.GetUserTasks(id);
            return tasks.OrderBy(task => task.TargetDate).ToList();
        }

        internal List<Tasks> GetTasksUptoTargetDate(string id, DateOnly filterDate)
        {
            List<Tasks> tasks = this._taskRepository.GetUserTasks(id);
            return tasks.OrderBy(task => task.TargetDate).Where(task => task.TargetDate < filterDate).ToList();
        }
    }
}
