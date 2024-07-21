using Microsoft.EntityFrameworkCore;
using Shared.Enum;
using TestSwaggerData.DataModel;
using TestSwaggerData.Interfaces;

namespace TestSwaggerData.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(Context dbContext) : base(dbContext) { }

        public List<User> UserForTaskLevel(TaskPriority taskLevel)
        {
            return _dbContext.Users
                        .Where(u => u.ToDoItems.Any(t => t.Priority.Level == taskLevel))
                        .Include(u => u.ToDoItems)
                        .ToList();
        }
    }
}
