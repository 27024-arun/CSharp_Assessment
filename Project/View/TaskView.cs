using ToDoApplication.Models;
using ToDoApplication.Services;

namespace ToDoApplication.View
{
    internal class TaskView
    {
        private readonly User _currentUser;
        private TaskSevices taskService;

        public TaskView(TaskSevices taskService)
        {
            this.taskService = taskService;
            this._currentUser = new User();
        }
        public void TaskMenu()
        {
            string taskMenu = $@"
=========TASK MENU=========";
        }
    }
}
