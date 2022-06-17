using System.Collections.Generic;
using System.Linq;
using LogicLayer.iFace;
using DataAccessLayer.Entities;


namespace LogicLayer.sortFactory
{
    public class ProjectSortFactory<ProjectDTO> : ISortFactory<ProjectDTO> where ProjectDTO : Project
    {
        public List<ProjectDTO> sort(string paramSort, List<ProjectDTO> projects)
        {
            switch (paramSort)
            {
                case "id_asc":
                    projects = projects.OrderBy(project => project.idProject).ToList();
                    break;
                case "id_desc":
                    projects = projects.OrderByDescending(project => project.idProject).ToList();
                    break;
                case "date_asc":
                    projects = projects.OrderBy(project => project.openingDate).ToList();
                    break;
                case "date_desc":
                    projects = projects.OrderByDescending(project => project.openingDate).ToList();
                    break;
                case "isComplited_asc":
                    projects = projects.OrderBy(project => project.isComplited).ToList();
                    break;
                case "isComplited_desc":
                    projects = projects.OrderByDescending(project => project.isComplited).ToList();
                    break;
            }
            return projects;
        }
    }
}
