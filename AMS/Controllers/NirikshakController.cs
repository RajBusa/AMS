using AMS.Repository;
using Microsoft.AspNetCore.Mvc;

namespace AMS.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NirikshakController : Controller
    {
        private readonly IMandalWithYuvakCountService _context;
        public NirikshakController(IMandalWithYuvakCountService context)
        {
            _context = context;
        }
            
        // GET: Kshetra
        [HttpGet]
        [Route("{id:int}/{isNirikshak:bool}")]
        public async Task<IActionResult> GetMandal([FromRoute]int id, [FromRoute] bool isNirikshak)
        {
            return Ok(await _context.GetMandal(id, isNirikshak));
        }

    }
}
