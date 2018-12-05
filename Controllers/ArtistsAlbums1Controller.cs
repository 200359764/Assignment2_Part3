using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SeunghwanKim_Assignment2_Part3.Models;

namespace SeunghwanKim_Assignment2_Part3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistsAlbums1Controller : ControllerBase
    {
        private readonly HighMMusicRecordsModel _context;

        public ArtistsAlbums1Controller(HighMMusicRecordsModel context)
        {
            _context = context;
        }

        // GET: api/ArtistsAlbums1
        [HttpGet]
        public IEnumerable<ArtistsAlbum> GetArtistsAlbums()
        {
            return _context.ArtistsAlbums;
        }

        // GET: api/ArtistsAlbums1/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetArtistsAlbum([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var artistsAlbum = await _context.ArtistsAlbums.FindAsync(id);

            if (artistsAlbum == null)
            {
                return NotFound();
            }

            return Ok(artistsAlbum);
        }

        // PUT: api/ArtistsAlbums1/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutArtistsAlbum([FromRoute] string id, [FromBody] ArtistsAlbum artistsAlbum)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != artistsAlbum.Title)
            {
                return BadRequest();
            }

            _context.Entry(artistsAlbum).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArtistsAlbumExists(id))
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

        // POST: api/ArtistsAlbums1
        [HttpPost]
        public async Task<IActionResult> PostArtistsAlbum([FromBody] ArtistsAlbum artistsAlbum)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.ArtistsAlbums.Add(artistsAlbum);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetArtistsAlbum", new { id = artistsAlbum.Title }, artistsAlbum);
        }

        // DELETE: api/ArtistsAlbums1/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArtistsAlbum([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var artistsAlbum = await _context.ArtistsAlbums.FindAsync(id);
            if (artistsAlbum == null)
            {
                return NotFound();
            }

            _context.ArtistsAlbums.Remove(artistsAlbum);
            await _context.SaveChangesAsync();

            return Ok(artistsAlbum);
        }

        private bool ArtistsAlbumExists(string id)
        {
            return _context.ArtistsAlbums.Any(e => e.Title == id);
        }
    }
}