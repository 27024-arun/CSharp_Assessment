using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApplication.Models
{
    internal class Tasks
    {

        /// <summary>
        /// Tasks is the constructor for instantiating Task Class.
        /// </summary>
        /// <param name="OwnerId">OwnerId is the id of the person who owns the task.</param>
        /// <param name="TaskName">TaskName is the name of the task.</param>
        /// <param name="Description">Description is the detail of implementation of the task.</param>
        /// <param name="TargetDate">TargetDate is the finishing time of the task.</param>
        /// <param name="TaskRecurrence">TaskRecurrence is the time for which the date should be occur again.</param>
        public Tasks(string OwnerId, string TaskName, string Description, DateOnly TargetDate, RecurrenceType TaskRecurrence)
        {
            this.OwnerId = OwnerId;
            this.TaskName = TaskName;
            this.Description = Description;
            this.TargetDate = TargetDate;
            this.TaskRecurrence = TaskRecurrence;
        }

        /// <summary>
        /// OwnerId is the id of the person who owns the task.
        /// </summary>
        public string OwnerId { get; set; }

        /// <summary>
        /// TaskName is the name of the task.
        /// </summary>
        public string TaskName { get; set; }

        /// <summary>
        /// Description is the detail of implementation of the task.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// TargetDate is the finishing time of the task.
        /// </summary>
        public DateOnly TargetDate { get; set; }

        /// <summary>
        /// TaskRecurrence is the time for which the date should be occur again.
        /// </summary>
        public RecurrenceType TaskRecurrence {  get; set; }
    }
}
