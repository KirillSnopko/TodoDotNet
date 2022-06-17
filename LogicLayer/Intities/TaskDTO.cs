using DataAccessLayer.Entities;
using System;

namespace LogicLayer.Intities
{
    public class TaskDTO
    {
        public int taskId { get; set; }
        public int projectId { get; set; }
        public string essence { get; set; }
        public DateTime date { get; set; }
        public bool isComplited { get; set; }

        public TaskDTO() { essence = ""; }
        public TaskDTO(Task task)
        {
            this.projectId = task.projectId;
            this.taskId = task.taskId;
            this.essence = task.essence;
            this.date = task.openingDate;
            this.isComplited = task.isComplited;
        }

        public bool isEmpty()
        {
            if (essence == "")
            {
                return true;
            }
            return false;
        }
    }
}
