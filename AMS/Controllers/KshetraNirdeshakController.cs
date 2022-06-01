using AMS.Models;
using AMS.Repository;
using Microsoft.AspNetCore.Mvc;

namespace AMS.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class KshetraNirdeshakController : Controller
    {
        private readonly IKshetraNirdeshakService _context;

        public KshetraNirdeshakController(IKshetraNirdeshakService context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> getAllKaryakar()
        {
            return Ok(await _context.GetAllKshetraNirdeshak());
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> getKaryakar(int id)
        {
            return Ok(await _context.GetKshetraNirdeshak(id));
        }

        [HttpPost]
        public async Task<IActionResult> insertKaryakar([FromBody] KshetraNirdeshak kshetraNirdesha)
        {
            return Ok(await _context.InsertKshetraNirdeshak(kshetraNirdesha));
        }

        [HttpPut]
        public async Task<IActionResult> updateKaryakar([FromBody] KshetraNirdeshak kshetraNirdesha)
        {
            return Ok(await _context.UpdateKshetraNirdeshak(kshetraNirdesha));
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> deletetKaryakar([FromRoute] int id)
        {
            return Ok(await _context.DeleteKshetraNirdeshak(id));
        }

    }
}
