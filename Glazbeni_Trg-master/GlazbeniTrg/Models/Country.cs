using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GlazbeniTrg.Models
{
    public class Country
    {
        [Key]
        public Guid CountryID { get; set; }

        [Required]
        [StringLength(100)]
        public String CountryName { get; set; }

        public virtual ICollection<City> Cities { get; set; }
    }
}
