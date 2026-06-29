using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.DTOs.BoardColumnDTOs
{
    public class CreateColumnRequest
    {
        public string ColumnName { get; set; } = string.Empty;
    }
}