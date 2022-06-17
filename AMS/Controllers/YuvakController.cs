using AMS.Models;
using AMS.Repository;
using Microsoft.AspNetCore.Mvc;

namespace AMS.Controllers
{
    //[ApiController]
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
        [Route("[action]/{id:int}/{isMandal:bool}")]
        public async Task<IActionResult> getKaryakarById(int id, bool isMandal)
        {
            return Ok(await _context.GetYuvakById(id, isMandal));
        }

        [HttpPost]
        [ActionName("insertYuvak")]
        public async Task<IActionResult> insertYuvak([FromBody] Yuvak yuvak)
        {
            return Ok(await _context.InsertYuvak(yuvak));
        }

        [HttpPut]
        public async Task<IActionResult> updateYuvak([FromBody] Yuvak yuvak)
        {
            return Ok(await _context.UpdateYuvak(yuvak));
        }
        [HttpPut]
        [Route("[action]/{id:int}")]
        public async Task<IActionResult> updateYuvakAttendance([FromRoute] int id, [FromBody] bool data)
        {
            return Ok(await _context.UpdateYuvakAttendance(id, data));
        }

        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> update([FromBody] List<int> yId, [FromBody] List<int> sId)
        {
            Console.WriteLine("Function Called");
            Console.WriteLine(yId.Count);
            Console.WriteLine(sId.Count);
            return Ok(await _context.UpdateSamparkId(yId, sId));
        }



        [HttpDelete]
        [Route("{id:int}")]
        [ActionName("deletetKaryakar")]
        public async Task<IActionResult> deletetYuvak([FromRoute] int id)
        {
            return Ok(await _context.DeleteYuvak(id));
        }

    }
}
