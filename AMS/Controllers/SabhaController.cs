using AMS.Models;
using AMS.Repository;
using Microsoft.AspNetCore.Mvc;

namespace AMS.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class SabhaController : Controller
    {
        private readonly ISabhaService _context;

        public SabhaController(ISabhaService context)
        {
            _context = context;
        }
        // Get All Sabha
        [HttpGet]

        public async Task<IActionResult> getSabha()
        {
            //Console.WriteLine("GetSabha is called");
            return Ok(await _context.GetAllSabha());
        }
        //Get Sabha By Id
        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> getSabhaById([FromRoute] int id)
        {
            return Ok(await _context.GetSabhaById(id));
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> getTotalSabhaByMandalId([FromRoute] int id)
        {
            //Console.WriteLine(id);
            return Ok(await _context.GetTotalSabhaByMandalId(id));
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> getUpComingSabhaByMandalId([FromRoute] int id)
        {
            //Console.WriteLine(await _context.GetUpComingSabhaByMandalId(id));
            return Ok(await _context.GetUpComingSabhaByMandalId(id));
        }

        [HttpPost]
        public async Task<IActionResult> insertSabha([FromBody] Sabha data)
        {
            return Ok(await _context.InsertSabha(data));
        }

        [HttpPut]
        public async Task<IActionResult> updateSabha([FromBody] Sabha data)
        {
            //Console.WriteLine("updateSabha Called 1");
            return Ok(await _context.UpdateSabha(data));
        }
    }
}
