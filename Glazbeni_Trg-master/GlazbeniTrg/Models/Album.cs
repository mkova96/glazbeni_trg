using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GlazbeniTrg.Models
{
    public class Album
    {


        public Album()
        {
            Genres = new JoinCollectionFacade<Genre, Album, AlbumGenre>(this, AlbumGenres);
            Songs = new JoinCollectionFacade<Song, Album, SongAlbum>(this, SongAlbums);
            ApplicationUsers = new JoinCollectionFacade<ApplicationUser, Album, Rating>(this, Ratings);

        }
        
        [Key]
        public Guid AlbumID { get; set; }

        [StringLength(100, ErrorMessage = "Ime mora biti kraće od 100 znakova!")]
        [Required]
        public String AlbumName { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime AlbumYear { get; set; }
        public Media Format { get; set; }

        [Range(0, 10000)]
        public int Stock { get; set; }

        [Range(0, 10000)]
        [DataType(DataType.Currency)]
        [Required]
        public decimal Price { get; set; }

        [Range(1, 5)]
        public decimal AvgGrade { get; set; }

        [DataType(DataType.MultilineText)]
        public String Description { get; set; }

        [Required]
        [DataType(DataType.ImageUrl)]
        public String ImagePath { get; set; }

        public Guid LabelID { get; set; }
        public virtual Label Label { get; set; }

        private ICollection<AlbumGenre> AlbumGenres { get; } = new List<AlbumGenre>();
        [NotMapped]
        public ICollection<Genre> Genres { get; }
        private ICollection<SongAlbum> SongAlbums { get; } = new List<SongAlbum>();
       
        public ICollection<Song> Songs { get; }


        private ICollection<CartAlbum> CartAlbums { get; } = new List<CartAlbum>();
        [NotMapped]
        public ICollection<Cart> Carts { get; }

        private ICollection<Rating> Ratings { get; } = new List<Rating>();
        [NotMapped]
        public ICollection<ApplicationUser> ApplicationUsers { get; }

    }
    public enum Media
    {
        CD, DVD, VINYL
    }
}

