using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GlazbeniTrg.Models.AccountViewModels
{
    public class ExternalLoginViewModel
    {

        [Required]
        [StringLength(100)]
        [Display(Name = "Ime")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Prezime")]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Adresa")]
        public string Address { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Poštanski broj")]
        public string PostCode { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Naziv mjesta")]
        public string CityName { get; set; }


        [Required]
        [Display(Name = "Država")]
        public Guid CountryID { get; set; }
    }
}
