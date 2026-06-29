using api.DTOs.BoardColumnDTOs;
using api.Services;
using Microsoft.AspNetCore.Mvc;

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