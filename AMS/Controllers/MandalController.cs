using AMS.Models;
using AMS.Repository;
using Microsoft.AspNetCore.Mvc;

namespace AMS.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MandalController : Controller
    {
        private readonly IMandalService _context;

        public MandalController(IMandalService context)
        {
            _context = context;
        }

        // GET All
        [HttpGet]
        //[Route("[action]")]
        public async Task<IActionResult> GetAllMandal()
        {
            return Ok(await _context.GetAllMandal());
        }
        //GET By ID
        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetMandalById([FromRoute] int id)
        {
            return Ok(await _context.GetMandalById(id));
        }

        [HttpGet]
        [Route("[action]/{id:int}")]
        public async Task<IActionResult> GetMandalName([FromRoute] int id)
        {
            return Ok(await _context.GetMandalName(id));
        }


        [HttpPost]
        public async Task<IActionResult> InsertMandal([FromBody] Mandal data)
        {
            return Ok(await _context.InsertMandal(data));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateMandal([FromBody] Mandal data)
        {
            return Ok(await _context.UpdateMandal(data));
        }


        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteMandal([FromRoute] int id)
        {
            return Ok(await _context.DeleteMandal(id));
        }
    }
}
