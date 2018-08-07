using Core.Model;
using System.Collections.Generic;

namespace Core.Model
{
    public class LandingPageData
    {
        public int ActiveUsers { get; set;}

        public int TotalTasks { get; set; }

        public ISet<Task> UserTasks { get; set; }
    }
}