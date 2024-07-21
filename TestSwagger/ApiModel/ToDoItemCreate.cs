using Shared.Enum;
using System.ComponentModel.DataAnnotations;

namespace TestSwagger.ApiModel
{
    public class ToDoItemCreate
    {
        public string Title { get; set; }
        public string Description { get; set; }       
        public DateTime DueDate { get; set; }

        [EnumDataType(typeof(TaskPriority))]
        public TaskPriority Priority { get; set; }
    }
}
