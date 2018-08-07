using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AppMVC.Models
{
    public class UserTasks
    {
        private string _title;

        public string Title
        {
            get => _title;
            set => _title = value.Trim();
        }

        public string UserName { get; set; }
        public DateTime InitialDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Message { get; set; }
        public long UserId { get; set; }
        [Key]
        public long TaskId { get; set; }
    }
}