using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;

namespace api.DTOs.BoardColumnDTOs
{
    public static class ColumnMapper
    {
        public static ColumnBoardResponse ToColumnBoardResponse(this BoardColumn boardColumn)
        {
            return new ColumnBoardResponse
            {
                Id = boardColumn.Id,
                Name = boardColumn.Name,
            };
        }
    }
}