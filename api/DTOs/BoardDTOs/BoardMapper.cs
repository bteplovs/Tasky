using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs.BoardColumnDTOs;
using api.DTOs.TaskItemDTOs;
using api.Models;

namespace api.DTOs.BoardDTOs
{
    public static class BoardMapper
    {
        public static SimpleBoardResponse ToSimpleBoardResponse(this Board board)
        {
            return new SimpleBoardResponse
            {
                Id = board.Id,
                Name = board.Name,
                // NumColumns = board.Columns?.Count ?? 0,
                NumTasks = board.Columns?.SelectMany(c => c.Tasks).Count() ?? 0
            };
        }

        public static BoardResponse ToBoardResponse(this Board board)
        {
            return new BoardResponse
            {
                Id = board.Id,
                Name = board.Name,
                Columns = board.Columns?
                    .Select(c => new ColumnBoardResponse
                    {
                        Id = c.Id,
                        Name = c.Name,
                        Tasks = c.Tasks?
                            .Select(t => new TaskBoardResponse
                            {
                                Id = t.Id,
                                Title = t.Title
                            }).ToList() ?? []
                    }).ToList() ?? new List<ColumnBoardResponse>()
            };
        }
    }
}