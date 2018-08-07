using Core.Boundaries;
using Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bondaries.Persistence
{
    public class EFTaskRepository : ITaskRepository
    {

        private TodoListContext _Context;

        public EFTaskRepository(TodoListContext context) => _Context = context;

        int ITaskRepository.GetTotalCount() => _Context.Tasks.Count();

        ISet<Core.Model.Task> ITaskRepository.GetTasksFor(User user)
            => new HashSet<Core.Model.Task>(_Context.Tasks.Where(t => t.UserId == user.UserId));
    }
}
