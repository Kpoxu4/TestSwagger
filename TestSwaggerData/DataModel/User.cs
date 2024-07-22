using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestSwaggerData.DataModel
{
    public class User : BaseModel
    {
        public string Name { get; set; }
        public virtual List<ToDoItem> ToDoItems { get; set; }  = new List<ToDoItem>();
    }
}
