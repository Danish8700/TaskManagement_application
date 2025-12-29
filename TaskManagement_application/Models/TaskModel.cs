using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaskManagement_application.Models
{
    public class TaskModel
    {

       
        public int TaskId { get; set; }
       
        public string TaskTitle { get; set; }
       
        public string TaskDescription { get; set; }
       
        public DateTime TaskDueDate { get; set; }
       
        public string TaskStatus { get; set; }
       
        public string TaskRemarks { get; set; }
       
        public int CreatedOn { get; set; }
       
        public int CreatedBy { get; set; }
       
        public int LastUpdatedBy { get; set; }
    }
}
//public class TaskModel
//{
//    public int TaskId { get; set; }
//    public string TaskTitle { get; set; }
//    public string TaskDescription { get; set; }
//    public DateTime TaskDueDate { get; set; }
//    public string TaskStatus { get; set; }
//    public string TaskRemarks { get; set; }

//    public int CreatedById { get; set; }        
//    public int? LastUpdatedById { get; set; }   

//    public string CreatedByName { get; set; } 
//    public string LastUpdatedByName { get; set; }

//    public DateTime CreatedOn { get; set; }
//    public DateTime? LastUpdatedOn { get; set; }
//}
