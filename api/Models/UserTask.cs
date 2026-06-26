using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class UserTask
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set;} = string.Empty;
        public DateTimeOffset? DueDate { get; set; }
        public DateTimeOffset Created { get; set; }
        public int UserId {get; set; }
        public int TaskListId { get; set; }
    }
}