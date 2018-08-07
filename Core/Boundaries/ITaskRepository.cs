using Core.Model;
using System.Collections.Generic;

namespace Core.Boundaries
{
    public interface ITaskRepository
    {
        int GetTotalCount();

        ISet<Task> GetTasksFor(User user);
    }
}