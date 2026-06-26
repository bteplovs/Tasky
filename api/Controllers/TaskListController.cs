using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    [Route("api/task-list")]
    [ApiController]
    public class TaskListController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        public TaskListController(ApplicationDBContext context)
        {
            _context = context;
            
        }

        [HttpGet]
        public async Task<ActionResult<TaskList>> GetAllTaskLists()
        {
            var taskLists = _context.TaskLists.Include(t=>t.Tasks).ToListAsync();
            return Ok(taskLists);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TaskList?>> GetTaskList([FromRoute] int id)
        {
            var taskList = _context.TaskLists.Include(t=>t.Tasks).Where(t=>t.Id == id).FirstOrDefaultAsync();
            
            if (taskList == null)
            {
                return NotFound();
            }

            return Ok(taskList);
        }

        [HttpPost]
        public async Task<ActionResult<CreatedTaskListResponse>> CreateTaskList([FromBody] CreateTaskListRequest request)
        {
            var newTaskList = await

            _context.TaskLists.Add(newTaskList);

        }

    }
}