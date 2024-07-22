using Shared.Enum;
using TestSwaggerData.DataModel;


namespace TestSwaggerData.Interfaces
{
    public interface IUserRepository : IBaseRepository<User>
    {
        List<User> UserForTaskLevel(TaskPriority taskLevel);     
    }
}