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
        public async Task<IActionResult> getAllYuvak()
        {
            return Ok(await _context.GetAllYuvak());
        }

        [HttpGet]
        [Route("[action]/{id:int}")]
        public async Task<IActionResult> getKaryakar(int id)
        {
            Console.WriteLine("getKaryakar");
            return Ok(await _context.GetYuvak(id));
        }
        
        [HttpGet]
        [Route("[action]/{id:int}")]
        public async Task<IActionResult> getKaryakarById(int id)
        {
            return Ok(await _context.GetYuvakById(id));
        }

        [HttpPost]
        [ActionName("insertKaryakar")]
        public async Task<IActionResult> insertKaryakar([FromBody] Yuvak yuvak)
        {
            return Ok(await _context.InsertYuvak(yuvak));
        }

        [HttpPut]
        [ActionName("updateKaryakar")]
        public async Task<IActionResult> updateKaryakar([FromBody] Yuvak yuvak)
        {
            return Ok(await _context.UpdateYuvak(yuvak));
        }

        [HttpDelete]
        [Route("{id:int}")]
        [ActionName("deletetKaryakar")]
        public async Task<IActionResult> deletetKaryakar([FromRoute] int id)
        {
            return Ok(await _context.DeleteYuvak(id));
        }

    }
}
