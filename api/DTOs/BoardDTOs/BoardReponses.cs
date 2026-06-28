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
    }

    public class BoardResponse
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<ColumnBoardResponse> Columns { get; set; } = new();
    }
}