using AMS.Models;
using AMS.Repository;
using Microsoft.AspNetCore.Mvc;

namespace AMS.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class YuvakController : Controller
    {
        private readonly IYuvakService _context;

        public YuvakController(IYuvakService context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> getAllKaryakar()
        {
            return Ok(await _context.GetAllYuvak());
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> getKaryakar(int id)
        {
            return Ok(await _context.GetYuvak(id));
        }

        [HttpPost]
        public async Task<IActionResult> insertKaryakar([FromBody] Yuvak yuvak)
        {
            return Ok(await _context.InsertYuvak(yuvak));
        }

        [HttpPut]
        public async Task<IActionResult> updateKaryakar([FromBody] Yuvak yuvak)
        {
            return Ok(await _context.UpdateYuvak(yuvak));
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> deletetKaryakar([FromRoute] int id)
        {
            return Ok(await _context.DeleteYuvak(id));
        }

    }
}
