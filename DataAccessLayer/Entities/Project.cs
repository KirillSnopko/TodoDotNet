using System;

namespace DataAccessLayer.Entities
{
    public class Project: IComparable<Project>
    {
        public int idProject { get; set; }
        public string name { get; set; }
        public DateTime openingDate { get; set; }
        public bool isComplited { get; set; }

        public Project() { }

        public Project(string essence)
        {
            this.name = essence;
        }

        public override string ToString()
        {
            return $"id={idProject}; essence={name}; date={openingDate}; isComplited={isComplited}";
        }

        public int CompareTo(Project other)
        {
            return this.idProject - other.idProject;
        }
    }
}
