using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SeunghwanKim_Assignment2_Part3.Models
{
    [Table("ArtistsAlbum")]
    public class ArtistsAlbum
    {
        [Key]
        public string Title { get; set; }

        public string Genre { get; set; }

        public string NameOfSong { get; set; }

        [Required]
        public string ArtistName { get; set; }

        public int YearOfRelease { get; set; }
    }
}
