using Shared.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestSwaggerData.DataModel;

namespace TestSwaggerData.Interfaces
{
    public interface IPriorityRepository : IBaseRepository<Priority>
    {
        Priority GetPriority(TaskPriority priority);
        void AddToDoItemInList(Priority priority, ToDoItem toDoItem);
    }
}
