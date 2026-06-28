using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs.TaskItemDTOs;
using api.Services;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/columns/{columnId:int}/tasks")]
    [ApiController]
    public class TaskItemController : ControllerBase
    {

        private readonly ITaskItemService _taskItemService;

        public TaskItemController(ITaskItemService taskItemService)
        {
            _taskItemService = taskItemService;
        }

        [HttpPost]
        public async Task<ActionResult<TaskBoardResponse>> CreateTaskItem([FromBody] CreateTaskItemRequest req, int columnId)
        {
            var newTaskItem = await _taskItemService.CreateTaskItemAsync(req, columnId);
            return Ok(newTaskItem.ToTaskBoardResponse());
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<TaskBoardResponse>> GetTaskItem(int id)
        {
            var taskItem = await _taskItemService.GetTaskItemAsync(id);
            if (taskItem == null) return NotFound();
            return Ok(taskItem.ToTaskBoardResponse());
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteTaskItem(int id)
        {
            var result = await _taskItemService.DeleteTaskItemAsync(id);
            if (!result) return NotFound();
            return Ok();
        }
    }
}