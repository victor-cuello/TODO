using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCWebApp.Models.UserTasks
{
    public class UserTasks
    {
        [Key]
        public long TaskId { get; set; }
        public string Tittle { get; set; }
        public long UserID { get; set; }
        public DateTime? DateCreation { get; set; }
        public DateTime? DateDue { get; set; }
    }
}