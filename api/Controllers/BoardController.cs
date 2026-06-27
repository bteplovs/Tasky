using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.DTOs.BoardDTOs;
using api.Models;
using api.Services;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/boards")]
    [ApiController]
    public class BoardController : ControllerBase
    {
        private readonly IBoardService _boardService;

        public BoardController(IBoardService boardService) 
        { 
            _boardService = boardService;
        }

        [HttpGet]
        public async Task<ActionResult<List<SimpleBoardResponse>>> GetAllBoards()
        {
            var boards = await _boardService.GetAllBoardsAsync();
            return Ok(boards.Select(b => SimpleBoardResponse.CreateFromBoard(b)).ToList());
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<BoardResponse>> GetBoard(int id)
        {
            var board = await _boardService.GetBoardAsync(id);
            if (board == null) return NotFound();
            return Ok(BoardResponse.CreateFromBoard(board));
        }

        [HttpPost]
        public async Task<ActionResult<SimpleBoardResponse>> CreateBoard([FromBody] CreateBoardRequest req)
        {
            var newBoard = await _boardService.CreateBoardAsync(req);
            return Ok(SimpleBoardResponse.CreateFromBoard(newBoard));
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteBoard(int id)
        {
            var result = await _boardService.DeleteBoardAsync(id);
            if (!result)
            {
                return NotFound();
            }

            return Ok();
        }
    }
}