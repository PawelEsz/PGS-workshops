using Microsoft.AspNetCore.Mvc;
using PGS.Kanban.Domain.DTOs;
using PGS.Kanban.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pgs.Kanban.Api.Controllers
{
    [Route("api/[controller]")]
    public class ListController : Controller
    {
        private readonly ListService _listService;

        public ListController()
        {
            _listService = new ListService();
        }

        [HttpPost]
        public IActionResult AddList([FromBody] AddListDto addListDto)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }

            var result = _listService.AddList(addListDto);

            if (result == null)
            {
                return BadRequest();
            }

            return Ok(result);
        }

        [HttpPut]
        public IActionResult EditListName([FromBody] EditListNameDto editListNameDto)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }

            var result = _listService.EditListName(editListNameDto);

            if (!result)
            {
                return BadRequest();
            }

            return NoContent();
        }

        [HttpDelete]
        public IActionResult DeleteList([FromBody] DeleteListDto deleteListDto)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }

            var result = _listService.DeleteList(deleteListDto);

            if(!result)
            {
                return BadRequest();
            }

            return NoContent();
        }
    }
}
