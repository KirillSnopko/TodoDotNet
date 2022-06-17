using DataAccessLayer.Exceptions;
using DataAccessLayer.repo;
using LogicLayer.Exceptions;
using LogicLayer.Intities;
using System;
using System.Collections.Generic;


namespace LogicLayer.services
{
    public class TaskService
    {
        private TaskRepo repo;

        public TaskService(string connection)
        {
            this.repo = new TaskRepo(connection);
        }

        public void insert(int idProject, string essence)
        {
            try
            {
                repo.insert(idProject, essence);
            }
            catch (DataAccessLayerException ex)
            {
                throw new OracleDbException(ex.Message, ex);
            }
        }

        public void delete(int idTask)
        {
            try
            {
                repo.delete(idTask);
            }
            catch (DataAccessLayerException ex)
            {
                throw new OracleDbException(ex.Message, ex);
            }
        }

        public void rename(int idTask, string newName)
        {
            try
            {
                repo.rename(idTask, newName);
            }
            catch (DataAccessLayerException ex)
            {
                throw new OracleDbException(ex.Message, ex);
            }
        }

        public List<TaskDTO> getAll(int idProject)
        {
            try
            {
                List<TaskDTO> tasksDTO = new List<TaskDTO>();
                repo.getAll(idProject).ForEach(s => tasksDTO.Add(new TaskDTO(s)));
                return tasksDTO;
            }
            catch (DataAccessLayerException ex)
            {
                throw new OracleDbException(ex.Message, ex);
            }
        }

        public void finish(int idTask)
        {
            try
            {
                repo.finish(idTask);
            }
            catch (DataAccessLayerException ex)
            {
                throw new OracleDbException(ex.Message, ex);
            }
        }

        public TaskDTO getById(int id)
        {
            try
            {
                return new TaskDTO(repo.getTaskById(id));
            }
            catch (NonExistentObjectException ex)
            {
                return new TaskDTO();
            }
            catch (DataAccessLayerException ex)
            {
                throw new OracleDbException(ex.Message, ex);
            }
        }
    }
}
