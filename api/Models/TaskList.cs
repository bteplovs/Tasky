using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class TaskList
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public int UserId {get; set; }
        public List<UserTask>? Tasks { get; set; }
    }
}