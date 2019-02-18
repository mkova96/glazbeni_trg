using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GlazbeniTrg.Models
{
    public class SongAlbum : IJoinEntity<Song>, IJoinEntity<Album>
    {
        public Guid SongID { get; set; }
        public Song Song { get; set; }
        Song IJoinEntity<Song>.Navigation {
            get => Song;
            set => Song = value;

        }


        public Guid AlbumID { get; set; }  
        public Album Album { get; set; }
        Album IJoinEntity<Album>.Navigation
        {
            get => Album;
            set => Album = value;
        }

    }
}
