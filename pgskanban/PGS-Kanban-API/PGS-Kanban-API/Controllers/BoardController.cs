using Microsoft.AspNetCore.Mvc;
using PGS.Kanban.Domain.DTOs;
using PGS.Kanban.Domain.DTOS;
using PGS.Kanban.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pgs.Kanban.Api.Controllers
{
    [Route("api/[controller]")]
    public class BoardController : Controller
    {
        private readonly BoardService _boardService;

        public BoardController()
        {
            _boardService = new BoardService();
        }

        [HttpGet]
        public IActionResult GetBoard()
        {
            var response = _boardService.GetBoard();

            if (response == null)
            {
                return NotFound();
            }

            return Ok(response);
        }

        [HttpPost]
        public IActionResult CreateBoard([FromBody] CreateBoardDto createBoardDto)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }

            var result = _boardService.CreateBoard(createBoardDto);

            return Ok(result);
        }



        //public IActionResult AddBoard([FromBody]BoardDto board)
        //{
        //    BoardDto b = new BoardDto()
        //    {
        //        Name = "ToDo",
        //    };

        //    _boardService.AddBoard(board);
        //    return NoContent();
        //}

        //[HttpDelete]
        //public IActionResult DeleteBoard()
        //{
        //    _boardService.DeleteBoard("ToDo");
        //    return NoContent();
        //}
    }
}
