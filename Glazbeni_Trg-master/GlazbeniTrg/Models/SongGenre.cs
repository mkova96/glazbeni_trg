using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GlazbeniTrg.Models
{
    public class SongGenre :IJoinEntity<Song>, IJoinEntity<Genre>
    {
        public Guid SongID { get; set; }
        public Song Song { get; set; }
        Song IJoinEntity<Song>.Navigation
        {
            get => Song;
            set => Song = value;
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
