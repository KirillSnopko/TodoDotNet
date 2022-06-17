using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TodoApp.entity
{
    public class Status
    {
        public int status { get; set; }
        public string message { get; set; }

        public Status(int status)
        {
            this.status = status;
        }

        public Status(int status, string message)
        {
            this.status = status;
            this.message = message;
        }
    }
}