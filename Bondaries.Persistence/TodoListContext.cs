using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVCWebApp.Models.UserTasks;

namespace Bondaries.Persistence
{
    public sealed class TodoListContext : DbContext
    {
        public TodoListContext() : base("ToDoListStr")
        {
            Tasks = Set<Core.Model.Task>();
            Database.Log = sql => Debug.Write(sql);
        }

        public DbSet<Core.Model.Task> Tasks { get; set; }

        public System.Data.Entity.DbSet<UserTasks> UserTasks { get; set; }
    }

    
}
