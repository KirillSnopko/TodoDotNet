using DataAccessLayer.Entities;
using System;
using System.Linq;

namespace LogicLayer.Intities
{
    public class ProjectDTO 
    {
        public ProjectDTO() 
        {
            name = "";
        }

        public int idProject { get; set; }
        public string name { get; set; }
        public DateTime openingDate { get; set; }
        public bool isComplited { get; set; }

        public ProjectDTO(Project project)
        {
            this.idProject = project.idProject;
            this.name = project.name;
            this.openingDate = project.openingDate;
            this.isComplited = project.isComplited;
        }

        public bool isEmpty()
        {
            if (name == "")
            {
                return true;
            }
            return false;
        }
    }
}
