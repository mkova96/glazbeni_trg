using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GlazbeniTrg.Models
{
    public class Rating :IJoinEntity<Album>, IJoinEntity<ApplicationUser>
    {
        public Guid AlbumID { get; set; }
        public Album Album { get; set; }
        Album IJoinEntity<Album>.Navigation
        {
            get => Album;
            set => Album = value;
        }

        public String Id{ get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        ApplicationUser IJoinEntity<ApplicationUser>.Navigation
        {
            get => ApplicationUser;
            set => ApplicationUser = value;
        }


        [Required]
        [Range(1, 5)]
        public int Grade { get; set; }

        [Required]
        public DateTime GradeDate { get; set; }

        
        

    }
}
