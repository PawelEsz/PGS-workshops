using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using PGS.Kanban.Domain.Services;

namespace Pgs.Kanban.Api.Controllers
{
    [Route("api/[controller]")]
    public class RandomGeneratorController : Controller
    {
        public RandomGeneratorService randomGeneratorService { get; set; }

        public RandomGeneratorController()
        {
            randomGeneratorService = new RandomGeneratorService();
        }
        
        [HttpGet]
        public IActionResult GetRandomNumber()
        {
            var number = randomGeneratorService.GenerateRandomNumber();

            return Ok(number);
        }

        [HttpGet]
        [Route("{maxValue}")]
        public IActionResult GetRandomNumber(int maxValue)
        {
            var number = randomGeneratorService.GenerateRandomNumber(maxValue);

            return Ok(number);
        }

        [HttpPost]
        [Route("{number}")]
        public IActionResult AddNumber(int number)
        {
            randomGeneratorService.AddNumberToList(number);

            return NoContent();
        }

        [HttpDelete]
        public IActionResult DeleteNumber(int number)
        {
            randomGeneratorService.DeleteNumberFromList(number);

            return NoContent();
        }

        [HttpGet]
        [Route("All")]
        public IActionResult GetAllNumbers()
        {
            return Ok(randomGeneratorService.GetAllNumbersFromList());
        }


    }
}
