using AMS.Models;
using AMS.Repository;
using Microsoft.AspNetCore.Mvc;

namespace AMS.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SabhaController : Controller
    {
        private readonly ISabhaService _context;

        public SabhaController(ISabhaService context)
        {
            _context = context;
        }

        // Get All Sabha
        [HttpGet]
        public async Task<IActionResult> GetSabha()
        {
            return Ok(await _context.GetAllSabha());
        }
        //Get Sabha By Id
        //[HttpGet]
        //[Route("{id:int}")]
        //public async Task<IActionResult> GetSabhaById([FromRoute]int id)
        //{
        //    return Ok(await _context.GetSabhaById(id));
        //}

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> getSabhaByMandalId([FromRoute] int id)
        {
            return Ok(await _context.GetSabhaByMandalId(id));
        }

        [HttpPost]
        public async Task<IActionResult> InsertSabha([FromBody] Sabha data)
        {
            return Ok(await _context.InsertSabha(data));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateSabha([FromBody] Sabha data)
        {
            return Ok(await _context.UpdateSabha(data));
        }

       
    }
}
