using LogicLayer.iFace;
using System.Collections.Generic;
using System.Linq;
using DataAccessLayer.Entities;

namespace LogicLayer.sortFactory
{
    public class TaskSortFactory<TaskDAO> : ISortFactory<TaskDAO> where TaskDAO : Task
    {
        public List<TaskDAO> sort(string paramSort, List<TaskDAO> list)
        {
            switch (paramSort)
            {
                case "id_asc":
                    list = list.OrderBy(task => task.taskId).ToList();
                    break;
                case "id_desc":
                    list = list.OrderByDescending(task => task.taskId).ToList();
                    break;
                case "date_asc":
                    list = list.OrderBy(task => task.openingDate).ToList();
                    break;
                case "date_desc":
                    list = list.OrderByDescending(task => task.openingDate).ToList();
                    break;
                case "isComplited_asc":
                    list = list.OrderBy(task => task.isComplited).ToList();
                    break;
                case "isComplited_desc":
                    list = list.OrderByDescending(task => task.isComplited).ToList();
                    break;
            }
            return list;
        }
    }
}
