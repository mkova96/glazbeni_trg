using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GlazbeniTrg.Models
{
    public class AlbumGenre : IJoinEntity<Album>, IJoinEntity<Genre>
    {
        public Guid AlbumID { get; set; }
        public Album Album { get; set; }
        Album IJoinEntity<Album>.Navigation
        {
            get => Album;
            set => Album = value;
        }

        public Guid GenreID { get; set; }
        public Genre Genre { get; set; }

        Genre IJoinEntity<Genre>.Navigation
        {
            get => Genre;
            set => Genre = value;
        }

        
    }
}
