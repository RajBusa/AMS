﻿using AMS.Repository;
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
