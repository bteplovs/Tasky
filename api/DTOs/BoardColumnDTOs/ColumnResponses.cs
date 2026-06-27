using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs.BoardDTOs;
using api.DTOs.TaskItemDTOs;
using api.Models;

namespace api.DTOs.BoardColumnDTOs
{
    public class ColumnBoardResponse
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<TaskBoardResponse>? Tasks { get; set; } = new();

        // Strictly for creating new columns, in this case there are no tasks in a new column
        public static ColumnBoardResponse FromBoardColumn(BoardColumn boardColumn)
        {
            return new ColumnBoardResponse
            {
                Id = boardColumn.Id,
                Name = boardColumn.Name,
            };
        }
    }
    
}