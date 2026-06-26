using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class BoardColumn
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Order { get; set; }

        public int BoardId { get; set; }
        public Board Board { get; set; } = null!;

        public List<TaskItem> Tasks { get; set; } = new();
    }
}