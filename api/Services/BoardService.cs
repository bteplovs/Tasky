using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Services
{
    public interface IBoardService
    {
        Task<List<Board>> GetAllBoardsAsync();
        Task<Board?> GetBoardAsync(int boardId);
        Task<Board> CreateBoardAsync(string name);
        Task<bool> DeleteBoardAsync(int boardId);
    }

    public class BoardService(IDbContextFactory<ApplicationDBContext> dbContextFactory) : IBoardService
    {
        public async Task<Board> CreateBoardAsync(string name)
        {
            await using var context = await dbContextFactory.CreateDbContextAsync();

            var board = new Board
            {
                Name = name,
            };

            context.Boards.Add(board);
            await context.SaveChangesAsync();

            return board;
        }

        public async Task<bool> DeleteBoardAsync(int boardId)
        {
            await using var context = await dbContextFactory.CreateDbContextAsync();

            var board = await context.Boards.FindAsync(boardId);

            if (board == null)
            {
                return false;
            }

            context.Boards.Remove(board);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Board>> GetAllBoardsAsync()
        {
            await using var context = await dbContextFactory.CreateDbContextAsync();

            var boards = await context.Boards.ToListAsync();

            return boards;
        }

        public async Task<Board?> GetBoardAsync(int boardId)
        {
            await using var context = await dbContextFactory.CreateDbContextAsync();

            var board = await context.Boards
                .Include(b => b.Columns)
                .ThenInclude(c => c.Tasks)
                .FirstOrDefaultAsync(b => b.Id == boardId);

            return board;
        }
    }
}