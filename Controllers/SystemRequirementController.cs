using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DealForge.API.Models;
using dealforgeApi.Models;

namespace dealforge_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SystemRequirementController : ControllerBase
    {
        private readonly AppDbContext _context;

        public SystemRequirementController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/SystemRequirement
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SystemRequirement>>> GetSystemRequirements()
        {
            return await _context.SystemRequirements.ToListAsync();
        }

        // GET: api/SystemRequirement/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SystemRequirement>> GetSystemRequirement(long id)
        {
            var systemRequirement = await _context.SystemRequirements.FindAsync(id);

            if (systemRequirement == null)
            {
                return NotFound();
            }

            return systemRequirement;
        }

        // PUT: api/SystemRequirement/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSystemRequirement(long id, SystemRequirement systemRequirement)
        {
            if (id != systemRequirement.Id)
            {
                return BadRequest();
            }

            _context.Entry(systemRequirement).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SystemRequirementExists(id))
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

        // POST: api/SystemRequirement
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SystemRequirement>> PostSystemRequirement(SystemRequirement systemRequirement)
        {
            _context.SystemRequirements.Add(systemRequirement);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSystemRequirement", new { id = systemRequirement.Id }, systemRequirement);
        }

        // DELETE: api/SystemRequirement/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSystemRequirement(long id)
        {
            var systemRequirement = await _context.SystemRequirements.FindAsync(id);
            if (systemRequirement == null)
            {
                return NotFound();
            }

            _context.SystemRequirements.Remove(systemRequirement);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SystemRequirementExists(long id)
        {
            return _context.SystemRequirements.Any(e => e.Id == id);
        }
    }
}
