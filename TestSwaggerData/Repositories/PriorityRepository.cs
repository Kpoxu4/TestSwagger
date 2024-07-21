using Shared.Enum;
using TestSwaggerData.DataModel;
using TestSwaggerData.Interfaces;

namespace TestSwaggerData.Repositories
{
    public class PriorityRepository : BaseRepository<Priority>, IPriorityRepository
    {
        public PriorityRepository(Context dbContext) : base(dbContext) { }

        public Priority GetPriority(TaskPriority priority)
        {

            return _dbSet.FirstOrDefault(x => x.Level == priority)!;

        }
        public void AddToDoItemInList(Priority priority, ToDoItem toDoItem)
        {
            priority.ToDoItems.Add(toDoItem);
            _dbContext.SaveChanges();
        }
    }
}
