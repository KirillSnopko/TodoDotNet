using DataAccessLayer.Entities;
using System.Collections.Generic;

namespace DataAccessLayer.iFaces
{
    public interface IProjectRepo
    {

        void insert(string name);

        void delete(int idProject);

        void rename(int idProject, string newName);

        void finish(int idProject);

        List<Project> getAll();

        Project getById(int idProject);
    }
}
