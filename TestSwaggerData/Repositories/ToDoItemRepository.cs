
using Microsoft.EntityFrameworkCore;
using Shared.Enum;
using TestSwaggerData.DataModel;
using TestSwaggerData.Interfaces;

namespace TestSwaggerData.Repositories
{
    public class ToDoItemRepository : BaseRepository<ToDoItem>, IToDoItemRepository
    {
        public ToDoItemRepository(Context dbContext) : base(dbContext) { }

        public List<ToDoItem> AllToDoItemForUser(int userId)
        {
            var user = _dbContext.Users
                                .Include(u => u.ToDoItems)
                                .FirstOrDefault(u => u.Id == userId);

            return user?.ToDoItems.ToList() ?? new List<ToDoItem>();
        }
        public List<ToDoItem> ListOfTasksForCertainLevel(TaskPriority taskLevel)
        {
            return _dbContext.ToDoItems
                            .Include(t => t.Priority)
                            .Where(t => t.Priority.Level == taskLevel)
                            .ToList();
        }
    }
}
