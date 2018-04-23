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
    public class CardController : Controller
    {
        private readonly CardService _cardService;

        public CardController()
        {
            _cardService = new CardService();
        }

        [HttpPost]
        public IActionResult AddCard([FromBody] AddCardDto addCardDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var result = _cardService.AddCard(addCardDto);

            if (result == null)
            {
                return BadRequest();
            }

            return Ok(result);
        }
    }
}
