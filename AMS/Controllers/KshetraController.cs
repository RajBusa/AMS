using AMS.Repository;
using Microsoft.AspNetCore.Mvc;

namespace AMS.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class KshetraController : Controller
    {
        private readonly IKshetraService _context;
        public KshetraController(IKshetraService context)
        {
            _context = context;
        }

        // GET: Kshetra
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return Ok(await _context.GetAllKshetra());
        }
    }
}
