using AMS.Repository;
using AMS.web.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Timers;
namespace AMS.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class KaryakarController : Controller
    {
        private readonly IKaryakarService _context;
        private static System.Timers.Timer aTimer;
        public KaryakarController(IKaryakarService context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> getAllKaryakar()
        {
            Console.WriteLine("Hey Started");
            aTimer = new System.Timers.Timer();
            aTimer.Interval = 2000;

            // Hook up the Elapsed event for the timer. 
             aTimer.Elapsed += hey;
             //aTimer.Elapsed += OnTimedEvent;

            // Have the timer fire repeated events (true is the default)
            aTimer.AutoReset = true;

            // Start the timer
            aTimer.Enabled = true;
            return Ok(await _context.GetAllKaryakar());
        }
        private static void OnTimedEvent(Object source, System.Timers.ElapsedEventArgs e)
        {
            Console.WriteLine("The Elapsed event was raised at {0}", e.SignalTime);
        }
        public static void hey(Object source,System.Timers.ElapsedEventArgs e)
        {
            Console.WriteLine("Hey 2 sec");
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
        public async Task<IActionResult> insertKaryakar([FromBody] Karyakar karyakar)
        {
            return Ok(await _context.InsertKaryakar(karyakar));
        }

        [HttpPut]
        public async Task<IActionResult> updateKaryakar([FromBody] Karyakar karyakar)
        {
            return Ok(await _context.UpdateKaryakar(karyakar));
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> deletetKaryakar([FromRoute] int id)
        {
            return Ok(await _context.DeleteKaryakar(id));
        }


    }
}
