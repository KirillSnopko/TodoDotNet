using System.Collections.Generic;
using DataAccessLayer.Entities;

namespace DataAccessLayer.iFaces
{
    public interface ITaskRepo
    {
        void insert(int idProject, string essence);

        void delete(int idTask);

        void rename(int idTask, string newName);

        List<Task> getAll(int idProject);

        void finish(int idTask);

        Task getTaskById(int id);
    }
}
