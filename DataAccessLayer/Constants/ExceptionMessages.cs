namespace DataAccessLayer.Constants
{
    class ExceptionMessages
    {
        //project
        public static string EXP_PROJ_DEL = "Exception with project DELETE operation. => ";
        public static string EXP_PROJ_INSERT = "Exception with project INSERT operation. => ";
        public static string EXP_PROJ_FIN = "Exception with project FINISH operation. => ";
        public static string EXP_PROJ_REN = "Exception with project RENAME operation. => ";
        public static string EXP_PROJ_ALL = "Exception with getting projects. => ";
        public static string EXP_PROJ_BY_ID = "Exception with getting project by id. => ";

        //task
        public static string EXP_TASK_DEL = "Exception with task DELETE operation. => ";
        public static string EXP_TASK_INSERT = "Exception with task INSERT operation. => ";
        public static string EXP_TASK_FIN = "Exception with task FINISH operation. => ";
        public static string EXP_TASK_REN = "Exception with task RENAME operation. => ";
        public static string EXP_TASK_ALL = "Exception with getting tasks by project id. => ";
        public static string EXP_TASK_BY_ID = "Exception with getting task by id. => ";

    }
}
