using Core.Boundaries;
using Core.Model;
using System;

namespace Core.UseCases
{
    public class LoadLandingPageData
    {
        private ITaskRepository taskRepo;
        private ISystemInfoRepository sysInfoRepo;

        public LoadLandingPageData(ITaskRepository taskRepo, ISystemInfoRepository sysInfoRepo)
        {
            this.taskRepo = taskRepo ?? throw new ArgumentNullException(nameof(taskRepo));
            this.sysInfoRepo = sysInfoRepo ?? throw new ArgumentNullException(nameof(sysInfoRepo));
        }

        public LandingPageData GetData(User theUser)
        {
            LandingPageData data = new LandingPageData{
                ActiveUsers = sysInfoRepo.GetActiveUsers(),
                TotalTasks = taskRepo.GetTotalCount(),
                UserTasks = taskRepo.GetTasksFor(theUser)
            };
            
            return data;
        }
    }
}