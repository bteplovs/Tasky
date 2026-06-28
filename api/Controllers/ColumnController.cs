using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using api.DTOs.BoardColumnDTOs;
using api.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata;

namespace api.Controllers
{
    [Route("api/boards/{boardId:int}/columns")]
    [ApiController]
    public class ColumnController : ControllerBase
    {
        private readonly IColumnService _columnService;

        public ColumnController(IColumnService columnService)
        {
            _columnService = columnService;
        }

        [HttpPost]
        public async Task<ActionResult<ColumnBoardResponse>> CreateColumn([FromBody] CreateColumnRequest req, int boardId)
        {
            var newColumn = await _columnService.CreatColumnAsync(req, boardId);
            return Ok(newColumn.ToColumnBoardResponse());
        }
    }
}