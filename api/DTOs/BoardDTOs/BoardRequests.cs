using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.DTOs.BoardDTOs
{
    public class CreateBoardRequest
    {
        public string boardName { get; set; } = string.Empty;
    }
}