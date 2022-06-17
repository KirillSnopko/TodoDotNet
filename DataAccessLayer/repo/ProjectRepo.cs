using DataAccessLayer.iFaces;
using System;
using Dapper;
using DataAccessLayer.Entities;
using System.Data;
using Oracle.DataAccess.Client;
using System.Collections.Generic;
using DataAccessLayer.Exceptions;
using static DataAccessLayer.Constants.SqlQuaries;
using static DataAccessLayer.Constants.ExceptionMessages;

namespace DataAccessLayer.repo
{
    public class ProjectRepo : IProjectRepo
    {
        private string connectionString;

        public ProjectRepo(string conn)
        {
            this.connectionString = conn;
        }

        public void insert(string name)
        {
            using (IDbConnection connection = new OracleConnection(connectionString))
            {
                try
                {
                    connection.Query(SQL_INSERT_PROJECT, new { name });
                }
                catch (Exception ex)
                {
                    throw new DataAccessLayerException(EXP_PROJ_INSERT + ex.Message, ex);
                }
            }
        }

        public void delete(int idProject)
        {
            using (IDbConnection connection = new OracleConnection(connectionString))
            {
                try
                {
                    connection.Execute(SQL_DELETE_PROJECT, new { idProject });
                }
                catch (Exception ex)
                {
                    throw new DataAccessLayerException(EXP_PROJ_DEL + ex.Message, ex);
                }
            }
        }

        public void finish(int idProject)
        {
            using (IDbConnection connection = new OracleConnection(connectionString))
            {
                try
                {
                    connection.Execute(SQL_FINISH_PROJECT, new { idProject });
                }
                catch (Exception ex)
                {
                    throw new DataAccessLayerException(EXP_PROJ_FIN + ex.Message, ex);
                }
            }
        }

        public List<Project> getAll()
        {
            List<Project> projects = new List<Project>();
            using (IDbConnection connection = new OracleConnection(connectionString))
            {
                try
                {
                    projects = connection.Query<Project>(SQL_GET_ALL_PROJECTS).AsList();
                }
                catch (Exception ex)
                {
                    throw new DataAccessLayerException(EXP_PROJ_ALL + ex.Message, ex);
                }
            }
            return projects;
        }

        public void rename(int idProject, string newName)
        {
            using (IDbConnection connection = new OracleConnection(connectionString))
            {
                try
                {
                    connection.Execute(SQL_RENAME_PROJECT, param: new { newName, idProject });
                }
                catch (Exception ex)
                {
                    throw new DataAccessLayerException(EXP_PROJ_REN + ex.Message, ex);
                }
            }
        }

        public Project getById(int idProject)
        {
            using (var connection = new OracleConnection(connectionString))
            {
                try
                {
                    Project project = connection.QueryFirst<Project>(SQL_GET_PROJECT_BY_ID, param: new { idProject });
                    return project;
                }
                catch (InvalidOperationException ex)
                {
                    throw new NonExistentObjectException(ex.Message, ex);
                }
                catch (Exception ex)
                {
                    throw new DataAccessLayerException(EXP_PROJ_BY_ID + ex.Message, ex);
                }
            }
        }
    }
}
