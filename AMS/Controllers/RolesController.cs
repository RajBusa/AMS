using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AMS.Data;
using AMS.web.Models;
using AMS.Repository;

namespace AMS.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RolesController : Controller
    {
        private readonly IRoleService _context;

        public RolesController(IRoleService context)
        {
            _context = context;
        }

        // GET: Roles
        [HttpGet]
        public async Task<IActionResult> getAllRoles()
        {
            return Ok(await _context.GetAllRoles());
        }

        [HttpPost]
        public async Task<IActionResult> InsertKaryakar([FromBody] KaryakarRole role)
        {
            return Ok(await _context.InsertKaryakarRole(role));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateKaryakarRole([FromBody] KaryakarRole role)
        {
            return Ok(await _context.UpdateKaryakar(role));
        }

        
        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteKaryakarRole([FromRoute]int id)
        {
            return Ok(await _context.DeleteYuvak(id));
        }
    }
}
