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
    public class PlatformController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PlatformController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Platform
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Platform>>> GetPlatforms()
        {
            return await _context.Platforms.ToListAsync();
        }

        // GET: api/Platform/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Platform>> GetPlatform(long id)
        {
            var platform = await _context.Platforms.FindAsync(id);

            if (platform == null)
            {
                return NotFound();
            }

            return platform;
        }

        // PUT: api/Platform/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlatform(long id, Platform platform)
        {
            if (id != platform.Id)
            {
                return BadRequest();
            }

            _context.Entry(platform).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlatformExists(id))
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

        // POST: api/Platform
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Platform>> PostPlatform(Platform platform)
        {
            _context.Platforms.Add(platform);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPlatform", new { id = platform.Id }, platform);
        }

        // DELETE: api/Platform/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlatform(long id)
        {
            var platform = await _context.Platforms.FindAsync(id);
            if (platform == null)
            {
                return NotFound();
            }

            _context.Platforms.Remove(platform);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PlatformExists(long id)
        {
            return _context.Platforms.Any(e => e.Id == id);
        }
    }
}
