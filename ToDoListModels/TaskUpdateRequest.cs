using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoListModels.Enums;

namespace ToDoListModels
{
    public class TaskUpdateRequest
    {
        public string TaskName { get; set; }
        public Priority Priority { get; set; }
    }
}
