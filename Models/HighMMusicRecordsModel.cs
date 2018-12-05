using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeunghwanKim_Assignment2_Part3.Models
{
    public class HighMMusicRecordsModel : DbContext
    {
        public HighMMusicRecordsModel(DbContextOptions<HighMMusicRecordsModel>options) : base(options)
        {
            
        }
        public DbSet<ArtistsAlbum> ArtistsAlbums { get; set; }
    }
}
