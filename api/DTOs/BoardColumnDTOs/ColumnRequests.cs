using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.DTOs.BoardColumnDTOs
{
    public class CreateColumnRequest
    {
        public int BoardId { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}