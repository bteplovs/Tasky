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
        Task<BoardColumn> CreatColumnAsync(CreateColumnRequest req, int boardId);
    }

    public class ColumnService(ApplicationDBContext dbContext) : IColumnService
    {
        public async Task<BoardColumn> CreatColumnAsync(CreateColumnRequest req, int boardId)
        {
            var boardColumn = new BoardColumn
            {
                BoardId = boardId,
                Name = req.ColumnName,
            }; 

            dbContext.BoardColumns.Add(boardColumn);
            await dbContext.SaveChangesAsync();

            return boardColumn;
        }
    }
}