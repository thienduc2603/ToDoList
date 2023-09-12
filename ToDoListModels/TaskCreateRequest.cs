using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoListModels.Enums;

namespace ToDoListModels
{
    public class TaskCreateRequest
    {
        public Guid Id { get; set; }
        [MaxLength(250)]
        [Required]
        public string TaskName { get; set; }
        public Priority Priority { get; set; }
    }
}
