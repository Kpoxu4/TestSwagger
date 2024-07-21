using Shared.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TestSwaggerData.DataModel
{
    public class Priority : BaseModel
    {
        public TaskPriority Level { get; set; }
        public virtual List<ToDoItem> ToDoItems { get; set; }
    }
}
