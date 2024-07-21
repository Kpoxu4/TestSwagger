using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestSwaggerData.DataModel
{
    public class ToDoItem : BaseModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }        
        public DateTime DueDate { get; set; }
        public virtual User? User { get; set; }
        public virtual Priority Priority { get; set; }  
    }
}
