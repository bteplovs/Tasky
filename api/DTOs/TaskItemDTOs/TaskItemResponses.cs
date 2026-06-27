using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.DTOs.TaskItemDTOs
{
    public class TaskBoardResponse
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
    }
}