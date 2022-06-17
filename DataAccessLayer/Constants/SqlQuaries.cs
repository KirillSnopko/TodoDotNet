namespace DataAccessLayer.Constants
{
    public class SqlQuaries
    {

        //QUARY FOR PROJECT TABLE (DAPPER_PROJECT)
        public static string SQL_DELETE_PROJECT = "delete from DAPPER_PROJECT where IDPROJECT = :idProject";
        public static string SQL_INSERT_PROJECT = "insert into DAPPER_PROJECT(idproject, name) values(AI_DAPPER_PROJECT.NEXTVAL,:name)";
        public static string SQL_RENAME_PROJECT = "update DAPPER_PROJECT set NAME = :newName where IDPROJECT = :idProject";
        public static string SQL_GET_ALL_PROJECTS = "select * from DAPPER_PROJECT";
        public static string SQL_FINISH_PROJECT = "update DAPPER_PROJECT set ISCOMPLITED = 1 where IDPROJECT = :idProject";
        public static string SQL_GET_PROJECT_BY_ID = "select * from DAPPER_PROJECT where IDPROJECT = :idProject";

        //QUARY FOR PROJECT TABLE (DAPPER_TASK)
        public static string SQL_DELETE_TASK = "delete from DAPPER_TASK where TASKID = :idTask";
        public static string SQL_INSERT_TASK = "insert into DAPPER_TASK(taskid, projectid, essence) values(AI_DAPPER_TASK.NEXTVAL, :idProject, :essence)";
        public static string SQL_RENAME_TASK = "update DAPPER_TASK set essence = :newName where TASKID = :idTask";
        public static string SQL_GET_TASK_BY_PRID = "select * from DAPPER_TASK where projectid = :idProject";
        public static string SQL_FINISH_TASK = "update DAPPER_TASK set ISCOMPLITED = 1 where TASKID = :idTask";
        public static string SQL_GET_TASK_BY_ID = "select * from DAPPER_TASK where TASKID = :idTask";
    }
}
