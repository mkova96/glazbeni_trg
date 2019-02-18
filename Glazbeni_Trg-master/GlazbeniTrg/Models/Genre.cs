using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace GlazbeniTrg.Models
{
    public class Genre
    {

        public Genre(){
            Albums = new JoinCollectionFacade<Album, Genre, AlbumGenre>(this, AlbumGenres);
            Songs = new JoinCollectionFacade<Song, Genre, SongGenre>(this, SongGenres);
        }

        [Key]
        public Guid GenreID { get; set; }

        [Required]
        [StringLength(100)]
        public String GenreName { get; set; }

        private ICollection<AlbumGenre> AlbumGenres { get; } = new List<AlbumGenre>();
        [NotMapped]
        public ICollection<Album> Albums { get; }
        private ICollection<SongGenre> SongGenres { get; } = new List<SongGenre>();
        [NotMapped]
        public ICollection<Song> Songs { get; }
    }
}
