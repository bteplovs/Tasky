using api.DTOs.BoardColumnDTOs;
using api.DTOs.TaskItemDTOs;
using api.Models;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace api.DTOs.BoardDTOs
{
    public class SimpleBoardResponse
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int NumColumns { get; set; }
        public int NumTasks { get; set; }

        public static SimpleBoardResponse CreateFromBoard(Board board)
        {
            return new SimpleBoardResponse
            {
                Id = board.Id,
                Name = board.Name,
                NumColumns = board.Columns?.Count ?? 0,
                NumTasks = board.Columns?.SelectMany(c => c.Tasks).Count() ?? 0
            };
        }
    }

    public class BoardResponse
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<ColumnBoardResponse> Columns { get; set; } = new();

        public static BoardResponse CreateFromBoard(Board board)
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