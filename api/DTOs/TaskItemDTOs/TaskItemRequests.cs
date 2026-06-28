using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.DTOs.TaskItemDTOs
{
    public class TaskItemRequests
    {
        public int Id { get; set; } // col ID
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}