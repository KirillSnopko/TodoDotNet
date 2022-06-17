using LogicLayer.Intities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TodoApp.Models
{
    public class ProjectDetails
    {
        public ProjectDTO project { get; set; }
        public List<TaskDTO> tasks { get; set; }

        public ProjectDetails(ProjectDTO project, List<TaskDTO> tasks)
        {
            this.project = project;
            this.tasks = tasks;
        }
    }
}