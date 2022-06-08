using AMS.Models;
using AMS.Repository;
using Microsoft.AspNetCore.Mvc;

namespace AMS.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SabhaAttendanceController : Controller
    {
        private readonly ISabhaAttendanceService _context;

        public SabhaAttendanceController(ISabhaAttendanceService context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> getAllSabhaAttendance()
        {
            return Ok(await _context.GetAllSabhaAttendance());
        }

        //[HttpGet]
        //[Route("{id:int}")]
        //public async Task<IActionResult> getSabhaAttendance(int id)
        //{
        //    return Ok(await _context.GetSabhaAttendance(id));
        //}

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> lastMonthSabha([FromRoute] int id)
        {
            return Ok(await _context.LastMonthSabha(id));
        }
        
        [HttpGet]
        [Route("{yid:int}/{sid:int}")]
        public async Task<IActionResult> ExistAttendance([FromRoute] int yid, [FromRoute] int sid)
        {
            return Ok(await _context.ExistAttendance(yid,sid));
        }

        [HttpPost]
        public async Task<IActionResult> insertSabhaAttendance([FromBody] SabhaAttendance sabhaAttendance)
        {
            return Ok(await _context.InsertSabhaAttendance(sabhaAttendance));
        }

        //[HttpPut]
        //public async Task<IActionResult> updateSabhaAttendance([FromBody] SabhaAttendance sabhaAttendance)
        //{
        //    return Ok(await _context.UpdateSabhaAttendance(sabhaAttendance));
        //}

        [HttpDelete]
        [Route("{yid:int}/{sid:int}")]
        public async Task<IActionResult> deleteSabhaAttendance([FromRoute] int yid, [FromRoute] int sid)
        {
            return Ok(await _context.DeleteSabhaAttendance(yid,sid));
        }
    }
}
