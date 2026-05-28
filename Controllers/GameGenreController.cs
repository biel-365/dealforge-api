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
    public class GameGenreController : ControllerBase
    {
        private readonly AppDbContext _context;

        public GameGenreController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/GameGenre
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GameGenre>>> GetGameGenres()
        {
            return await _context.GameGenres.ToListAsync();
        }

        // GET: api/GameGenre/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GameGenre>> GetGameGenre(long id)
        {
            var gameGenre = await _context.GameGenres.FindAsync(id);

            if (gameGenre == null)
            {
                return NotFound();
            }

            return gameGenre;
        }

        // PUT: api/GameGenre/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGameGenre(long id, GameGenre gameGenre)
        {
            if (id != gameGenre.Id)
            {
                return BadRequest();
            }

            _context.Entry(gameGenre).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GameGenreExists(id))
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

        // POST: api/GameGenre
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<GameGenre>> PostGameGenre(GameGenre gameGenre)
        {
            _context.GameGenres.Add(gameGenre);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGameGenre", new { id = gameGenre.Id }, gameGenre);
        }

        // DELETE: api/GameGenre/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGameGenre(long id)
        {
            var gameGenre = await _context.GameGenres.FindAsync(id);
            if (gameGenre == null)
            {
                return NotFound();
            }

            _context.GameGenres.Remove(gameGenre);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GameGenreExists(long id)
        {
            return _context.GameGenres.Any(e => e.Id == id);
        }
    }
}
