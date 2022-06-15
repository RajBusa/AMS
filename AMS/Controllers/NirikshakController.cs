using AMS.Repository;
using Microsoft.AspNetCore.Mvc;

namespace AMS.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NirikshakController : Controller
    {
        private readonly INirikshakService _context;
        public NirikshakController(INirikshakService context)
        {
            _context = context;
        }

        // GET: Kshetra
        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetAllMandal([FromRoute]int id)
        {
            return Ok(await _context.GetAllMandal(id));
        }

    }
}
