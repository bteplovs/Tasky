using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.DTOs.TaskItemDTOs;
using api.Models;

namespace api.Services
{
    public interface ITaskItemService
    {
     // Create task
     Task<TaskItem> CreateTaskItemAsync(CreateTaskItemRequest req, int columnId); 
     // Get task
     Task<TaskItem?> GetTaskItemAsync(int taskId);
     // Update Task
     Task<TaskItem> UpdateTaskItemAsync(int taskId);
     // Delete Task  
     Task<bool> DeleteTaskItemAsync(int taskId);
    }

    public class TaskItemService(ApplicationDBContext dbContext) : ITaskItemService
    {
        public async Task<TaskItem> CreateTaskItemAsync(CreateTaskItemRequest req, int columnId)
        {
            var taskItem = new TaskItem
            {
                Title = req.Title,
                BoardColumnId = columnId
            };

            dbContext.TaskItems.Add(taskItem);
            await dbContext.SaveChangesAsync();

            return taskItem;
        }

        public async Task<bool> DeleteTaskItemAsync(int taskId)
        {
            var taskItem = dbContext.TaskItems.Find(taskId);

            if (taskItem == null)
            {
                return false;
            }

            dbContext.TaskItems.Remove(taskItem);
            await dbContext.SaveChangesAsync();
            return true;

        }

        public async Task<TaskItem?> GetTaskItemAsync(int taskId)
        {
            var taskItem = dbContext.TaskItems.Find(taskId);
            
            return taskItem;
        }

        public async Task<TaskItem> UpdateTaskItemAsync(int taskId)
        {
            throw new NotImplementedException(); // replace entire resource or partial update.
        }
    }
}