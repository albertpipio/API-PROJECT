using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiEmpleats.Data;
using ApiEmpleats.Models;

namespace ApiEmpleats.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleatInfoController : ControllerBase
    {
        private readonly EmpleatContext _context;

        public EmpleatInfoController(EmpleatContext context)
        {
            _context = context;
        }

        // GET: api/EmpleatInfo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmpleatInfo>>> GetEmpleatsInfo()
        {
            return await _context.EmpleatsInfo.ToListAsync();
        }

        // GET: api/EmpleatInfo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EmpleatInfo>> GetEmpleatInfo(long id)
        {
            var empleatInfo = await _context.EmpleatsInfo.FindAsync(id);

            if (empleatInfo == null)
            {
                return NotFound();
            }

            return empleatInfo;
        }

        // PUT: api/EmpleatInfo/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmpleatInfo(long id, EmpleatInfo empleatInfo)
        {
            if (id != empleatInfo.Id)
            {
                return BadRequest();
            }

            _context.Entry(empleatInfo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmpleatInfoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/EmpleatInfo
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EmpleatInfo>> PostEmpleatInfo(EmpleatInfo empleatInfo)
        {
            _context.EmpleatsInfo.Add(empleatInfo);
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GetEmpleatInfo", new { id = empleatInfo.Id }, empleatInfo);
            return CreatedAtAction(nameof(GetEmpleatInfo), new { id = empleatInfo.Id }, empleatInfo);
        }

        // DELETE: api/EmpleatInfo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmpleatInfo(long id)
        {
            var empleatInfo = await _context.EmpleatsInfo.FindAsync(id);
            if (empleatInfo == null)
            {
                return NotFound();
            }

            _context.EmpleatsInfo.Remove(empleatInfo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EmpleatInfoExists(long id)
        {
            return _context.EmpleatsInfo.Any(e => e.Id == id);
        }
    }
}
