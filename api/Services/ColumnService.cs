using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.DTOs.BoardColumnDTOs;
using api.DTOs.BoardDTOs;
using api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace api.Services
{
    public interface IColumnService
    {
        // POST
        // PATCH
        // DELETE
        Task<BoardColumn> CreatColumnAsync(CreateColumnRequest req);
    }

    public class ColumnService(ApplicationDBContext dbContext) : IColumnService
    {
        public async Task<BoardColumn> CreatColumnAsync(CreateColumnRequest req)
        {
            var boardColumn = new BoardColumn
            {
                BoardId = req.BoardId,
                Name = req.Name,
            }; 

            await dbContext.BoardColumns.AddAsync(boardColumn);
            await dbContext.SaveChangesAsync();

            return boardColumn;
        }
    }
}