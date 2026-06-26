using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.DTOs.BoardDTOs;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Services
{
    public interface IBoardService
    {
        Task<List<Board>> GetAllBoardsAsync();
        Task<Board?> GetBoardAsync(int boardId);
        Task<Board> CreateBoardAsync(CreateBoardRequest req);
        Task<bool> DeleteBoardAsync(int boardId);
    }

    public class BoardService(ApplicationDBContext dbContext) : IBoardService
    {
        public async Task<Board> CreateBoardAsync(CreateBoardRequest req)
        {

            var board = new Board
            {
                Name = req.Name,
            };

            dbContext.Boards.Add(board);
            await dbContext.SaveChangesAsync();

            return board;
        }

        public async Task<bool> DeleteBoardAsync(int boardId)
        {

            var board = await dbContext.Boards.FindAsync(boardId);

            if (board == null)
            {
                return false;
            }

            dbContext.Boards.Remove(board);
            await dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<List<Board>> GetAllBoardsAsync()
        {

            var boards = await dbContext.Boards.ToListAsync();

            return boards;
        }

        public async Task<Board?> GetBoardAsync(int boardId)
        {

            var board = await dbContext.Boards
                .Include(b => b.Columns)
                .ThenInclude(c => c.Tasks)
                .FirstOrDefaultAsync(b => b.Id == boardId);

            return board;
        }
    }
}