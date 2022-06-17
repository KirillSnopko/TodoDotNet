using System;

namespace DataAccessLayer.Entities
{
    public class Task
    {
        public int taskId { get; set; }
        public int projectId { get; set; }
        public string essence { get; set; }
        public DateTime openingDate { get; set; }
        public bool isComplited { get; set; }

        public Task() { }

        public Task(string essence, int id)
        {
            this.essence = essence;
        }

        public override string ToString()
        {
            return $"id={taskId}; IDPROJECT={projectId}; essence={essence}; date={openingDate}; isComplited={isComplited}";
        }
    }
}

