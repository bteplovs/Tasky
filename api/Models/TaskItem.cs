using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class TaskItem
    {
        public int Id { get; set; }
        public string Title {get; set; } = string.Empty;
        public string? Description { get; set; }

        public int BoardColumnId { get; set; }
        public BoardColumn BoardColumn { get; set; } = null!;

        public int Order { get; set; } 
    }
}