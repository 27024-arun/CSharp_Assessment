using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApplication.Services;

namespace ToDoApplication.View
{
    internal class TaskView
    {
        private TaskSevices taskService;

        public TaskView(TaskSevices taskService)
        {
            this.taskService = taskService;
        }
    }
}
