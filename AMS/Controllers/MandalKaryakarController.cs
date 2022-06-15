using AMS.Models;
using AMS.Repository;
using Microsoft.AspNetCore.Mvc;

namespace AMS.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MandalKaryakarController : Controller
    {
        private readonly IMandalKaryakarService _context;

        public MandalKaryakarController(IMandalKaryakarService context)
        {
            _context = context;
        }

        // GET: Roles
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _context.GetAllMandalKaryakar());
        }

        [HttpPost]
        public async Task<IActionResult> InsertMandalKaryakar([FromBody] MandalKaryakar data)
        {
            return Ok(await _context.AddMandalKaryakar(data));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateMandalKaryakarRole([FromBody] MandalKaryakar data)
        {
            return Ok(await _context.UpdateMandalKaryakar(data));
        }


        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteMandalKaryakar([FromRoute] int id)
        {
            return Ok(await _context.DeleteMandalKaryakar(id));
        }
    }
}
