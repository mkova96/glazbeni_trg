using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GlazbeniTrg.Models
{
    public class Song
    {

        public Song()
        {
            Albums = new JoinCollectionFacade<Album, Song, SongAlbum>(this, SongAlbums);
            Genres = new JoinCollectionFacade<Genre, Song, SongGenre>(this, SongGenres);
        }
        [Key]
        public Guid SongID { get; set; }

        [Required]
        [StringLength(100)]
        public String SongName { get; set; }

        [DataType(DataType.Duration)]
        public TimeSpan Duration { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy}", ApplyFormatInEditMode = true)]
        public DateTime SongYear { get; set; }

        private ICollection<SongGenre> SongGenres { get; } = new List<SongGenre>();
        [NotMapped]
        public ICollection<Genre> Genres { get; }

        private ICollection<SongAlbum> SongAlbums { get; } = new List<SongAlbum>();
        [NotMapped]
        public ICollection<Album> Albums { get; }
        public ICollection<SongPerson> SongPersons { get; } = new List<SongPerson>();
        
    }
}
