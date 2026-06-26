using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Models;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/board")]
    [ApiController]
    public class BoardController : ControllerBase
    {
        private readonly ApplicationDBContext _context;

        public BoardController(ApplicationDBContext context) 
        { 
            _context = context; 
        
        }

        [HttpGet]
        public async Task<ActionResult<List<Board>>> GetAllBoards()
        {
            var Boards = await 
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Board>> GetBoard()
        {
            
        }

    }
}