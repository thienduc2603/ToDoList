using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoListModels.Enums;

namespace ToDoListModels
{
    public class TaskDto
    {
        public Guid Id { get; set; }
        public string TaskName { get; set; }
        public DateTime CreatedDate { get; set; }
        public Priority Priority { get; set; }
        public Status Status { get; set; }
        public Guid? AssigneeId { get; set; }
        public string AssgineeName { get; set; }
    }
}
