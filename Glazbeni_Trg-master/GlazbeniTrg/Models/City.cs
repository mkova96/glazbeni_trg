using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GlazbeniTrg.Models
{
    public class City
    {
        [Key]
        public Guid CityID { get; set; }
        public int PostCode { get; set; }

        [Required]
        [StringLength(100)]
        public String CityName { get; set; }

        public Guid CountryID { get; set; }
        public virtual Country Country { get; set; }
    }
}
