using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SeunghwanKim_Assignment2_Part3.Models;

namespace SeunghwanKim_Assignment2_Part3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistsAlbumsController : ControllerBase
    {
        private HighMMusicRecordsModel db;

        public ArtistsAlbumsController(HighMMusicRecordsModel db)
        {
            this.db = db;
        }

        [HttpGet]
        public IEnumerable<ArtistsAlbum> Get()
        {
            return db.ArtistsAlbums.OrderBy(a => a.Title).ToList();
        }

        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            ArtistsAlbum artistsAlbum = db.ArtistsAlbums.Find(id);

            if (artistsAlbum == null)
            {
                return NotFound();
            }
            return Ok(artistsAlbum);
        }

        [HttpPost]
        public ActionResult Post([FromBody] ArtistsAlbum artistsAlbum)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ArtistsAlbums.Add(artistsAlbum);
            db.SaveChanges();
            return CreatedAtAction("Post", artistsAlbum);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] ArtistsAlbum artistsAlbum)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Entry(artistsAlbum).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            ArtistsAlbum artistsAlbum = db.ArtistsAlbums.Find(id);

            if (artistsAlbum == null)
            {
                return NotFound();
            }

            db.ArtistsAlbums.Remove(artistsAlbum);
            db.SaveChanges();
            return Ok();
        }
    }
}