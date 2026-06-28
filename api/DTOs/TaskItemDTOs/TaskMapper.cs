using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;

namespace api.DTOs.TaskItemDTOs
{
    public static class TaskMapper
    {
        public static TaskBoardResponse ToTaskBoardResponse(this TaskItem taskItem)
        {
            return new TaskBoardResponse
            {
                Id = taskItem.Id,
                Title = taskItem.Title
            }
        }
    }
}