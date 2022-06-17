using System.Collections.Generic;
using DataAccessLayer.iFaces;
using LogicLayer.Exceptions;
using LogicLayer.Intities;
using DataAccessLayer.Exceptions;
using DataAccessLayer.repo;
using DataAccessLayer.Entities;

namespace LogicLayer.services
{
    public class ProjectService
    {
        private IProjectRepo projectRepo;

        public ProjectService(string connection)
        {
            this.projectRepo = new ProjectRepo(connection);
        }

        public List<ProjectDTO> getProjects()
        {
            try
            {
                List<ProjectDTO> projectsDTO = new List<ProjectDTO>();
                projectRepo.getAll().ForEach(s => projectsDTO.Add(new ProjectDTO(s)));
                return projectsDTO;
            }
            catch (DataAccessLayerException ex)
            {
                throw new OracleDbException(ex.Message, ex);
            }
        }

        public void insert(string name)
        {
            try
            {
                projectRepo.insert(name);
            }
            catch (DataAccessLayerException ex)
            {
                throw new OracleDbException(ex.Message, ex);
            }
        }

        public void delete(int idProject)
        {
            try
            {
                projectRepo.delete(idProject);
            }
            catch (DataAccessLayerException ex)
            {
                throw new OracleDbException(ex.Message, ex);
            }

        }

        public void rename(int idProject, string newName)
        {
            try
            {
                projectRepo.rename(idProject, newName);
            }
            catch (DataAccessLayerException ex)
            {
                throw new OracleDbException(ex.Message, ex);
            }
        }

        public void finish(int idProject)
        {
            try
            {
                projectRepo.finish(idProject);
            }
            catch (DataAccessLayerException ex)
            {
                throw new OracleDbException(ex.Message, ex);
            }
        }

        public ProjectDTO getProjectById(int id)
        {
            try
            {
                return new ProjectDTO(projectRepo.getById(id));
            }
            catch (NonExistentObjectException ex)
            {
                return new ProjectDTO();
            }
            catch (DataAccessLayerException ex)
            {
                throw new OracleDbException(ex.Message, ex);
            }
        }
    }
}
