using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GlazbeniTrg.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        
        public ApplicationUser()
        {
            Albums = new JoinCollectionFacade<Album, ApplicationUser, Rating>(this, Ratings);
        }
        [Required]
        [StringLength(100)]
        public String FirstName { get; set; }

        [Required]
        [StringLength(100)]
        public String LastName { get; set; }
        
        [Required]
        public String Address { get; set; }

        public Guid CityID { get; set; }
        public virtual City City { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
        

        private ICollection<Rating> Ratings { get; } = new List<Rating>();
        [NotMapped]
        public ICollection<Album> Albums { get; }

        public virtual ICollection<Genre> PrefGenres { get; set; }
        public virtual ICollection<Person> PrefArtists
        {
            get; set;
        }
    }
}
