using Shared.Enum;
using TestSwaggerData.DataModel;


namespace TestSwaggerData.Interfaces
{
    public interface IToDoItemRepository : IBaseRepository<ToDoItem>
    {
        List<ToDoItem> AllToDoItemForUser(int userId);
        List<ToDoItem> ListOfTasksForCertainLevel(TaskPriority taskLevel);
        List<ToDoItem> FilterByStatus(bool status);
        void AddUser(User user, ToDoItem toDoItem);
    }
}