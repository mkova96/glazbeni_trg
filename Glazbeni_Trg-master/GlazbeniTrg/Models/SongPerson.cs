using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GlazbeniTrg.Models
{
    public class SongPerson :IJoinEntity<Song>, IJoinEntity<Person>
    {
        public Guid SongID { get; set; }
        public Song Song { get; set; }
        Song IJoinEntity<Song>.Navigation
        {
            get => Song;
            set => Song = value;
        }



        public Guid PersonID { get; set; }
        public Person Person { get; set; }
        Person IJoinEntity<Person>.Navigation
        {
            get => Person;
            set => Person = value;
        }
      
        public Function Function { get; set; }




    }
    public enum Function
    {
        PRODUCER, PERFORMER, COMPOSER, SONGWRITER, SINGER, DRUMMER, BASSIST, GUITARIST
    }
}
