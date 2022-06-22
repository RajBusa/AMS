using AMS.Models;
using AMS.Repository;
using AMS.web.Models;
using Microsoft.AspNetCore.Mvc;
namespace AMS.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class KaryakarController : Controller
    {
        private readonly IKaryakarService _context;
        public KaryakarController(IKaryakarService context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> getAllKaryakar()
        {
            return Ok(await _context.GetAllKaryakar());
        }
        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> getKaryakar(int id)
        {
            return Ok(await _context.GetKaryakar(id));
        }

        [HttpGet]
        [Route("[action]/{mId:int}")]
        public async Task<IActionResult> getSamparkKaryakar(int mId)
        {
            return Ok(await _context.GetSamparKaryakars(mId));
        }
        [HttpGet]
        [Route("[action]/{mId:int}")]
        public async Task<IActionResult> getSanchalak(int mId)
        {
            return Ok(await _context.GetSanchalak(mId));
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> getKaryakarByEmailId([FromBody]string email)
        {
            return Ok(await _context.GetKaryakarByEmailId(email));
        }



        [HttpGet]
        [Route("[action]/{id:int}")]
        public async Task<IActionResult> GetAllYuvaks([FromRoute] int id)
        {
            return Ok(await _context.GetAllYuvaks(id));
        }
        //[HttpGet]
        //[Route("[action]")]
        //public async Task<IActionResult> getSamparkId()
        //{
        //    return Ok(await _context.GetSamparkId());
        //}

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> insertKaryakar([FromBody] Karyakar karyakar)
        {
            return Ok(await _context.InsertKaryakar(karyakar));
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> insertKaryakarFromYuvakId([FromBody] int[] yId)
        {
            //Console.WriteLine(yId);
            return Ok(await _context.InsertKaryakarFromYuvakId(yId));
        }

        [HttpPut]

        public async Task<IActionResult> updateKaryakar([FromBody] Karyakar karyakar)
        {
            return Ok(await _context.UpdateKaryakar(karyakar));
        }

        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> SignIn([FromBody] SignIn signIn)
        {
            return Ok(await _context.SignIn(signIn));
        }

        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> changePassword([FromBody] SignIn signIn)
        {
            return Ok(await _context.changePassword(signIn));
        }


        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> deletetKaryakar([FromRoute] int id)
        {
            return Ok(await _context.DeleteKaryakar(id));
        }
    }
}
