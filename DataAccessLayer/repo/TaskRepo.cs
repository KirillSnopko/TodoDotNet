using System;
using System.Collections.Generic;
using DataAccessLayer.Entities;
using DataAccessLayer.iFaces;
using System.Data;
using Oracle.DataAccess.Client;
using static DataAccessLayer.Constants.SqlQuaries;
using static DataAccessLayer.Constants.ExceptionMessages;
using Dapper;
using DataAccessLayer.Exceptions;

namespace DataAccessLayer.repo
{
    public class TaskRepo : ITaskRepo
    {
        private string connectionString;

        public TaskRepo(string connectionString)
        {
            this.connectionString = connectionString;
        }


        public void insert(int idProject, string essence)
        {
            using (IDbConnection connection = new OracleConnection(connectionString))
            {
                try
                {
                    connection.Query(SQL_INSERT_TASK, new { idProject, essence });
                }
                catch (Exception ex)
                {
                    throw new DataAccessLayerException(EXP_TASK_INSERT + ex.Message, ex);
                }
            }
        }

        public void delete(int idTask)
        {
            using (IDbConnection connection = new OracleConnection(connectionString))
            {
                try
                {
                    connection.Execute(SQL_DELETE_TASK, new { idTask });
                }
                catch (Exception ex)
                {
                    throw new DataAccessLayerException(EXP_TASK_DEL + ex.Message, ex);
                }
            }
        }

        public void finish(int idTask)
        {
            using (IDbConnection connection = new OracleConnection(connectionString))
            {
                try
                {
                    connection.Execute(SQL_FINISH_TASK, new { idTask });
                }
                catch (Exception ex)
                {
                    throw new DataAccessLayerException(EXP_TASK_FIN + ex.Message, ex);
                }
            }
        }

        public List<Task> getAll(int idProject)
        {
            List<Task> tasks = new List<Task>();
            using (IDbConnection connection = new OracleConnection(connectionString))
            {
                try
                {
                    tasks = connection.Query<Task>(SQL_GET_TASK_BY_PRID, new { idProject }).AsList();
                }
                catch (Exception ex)
                {
                    throw new DataAccessLayerException(EXP_TASK_ALL + ex.Message, ex);
                }
            }
            return tasks;
        }

        public void rename(int idTask, string newName)
        {
            using (IDbConnection connection = new OracleConnection(connectionString))
            {
                try
                {
                    connection.Execute(SQL_RENAME_TASK, new { idTask, newName });
                }
                catch (Exception ex)
                {
                    throw new DataAccessLayerException(EXP_TASK_REN, ex);
                }
            }
        }

        public Task getTaskById(int idTask)
        {
            using (var connection = new OracleConnection(connectionString))
            {
                try
                {
                    Task task = connection.QueryFirst<Task>(SQL_GET_TASK_BY_ID, param: new { idTask });
                    return task;
                }
                catch (InvalidOperationException ex)
                {
                    throw new NonExistentObjectException(ex.Message, ex);
                }
                catch (Exception ex)
                {
                    throw new DataAccessLayerException(EXP_TASK_BY_ID + ex.Message, ex);
                }
            }
        }
    }
}
