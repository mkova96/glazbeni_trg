using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GlazbeniTrg.Models.AccountViewModels
{
    public class RegisterViewModel
    {
        
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Lozinka mora sadržavati najmanje {2} znakova, a najviše {1}.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Lozinka")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Potvrdi lozinku")]
        [Compare("Password", ErrorMessage = "Lozinka i potvrda lozinke se ne poklapaju.")]
        public string ConfirmPassword { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Ime")]
        public string Name { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Prezime")]
        public string LastName { get; set; }

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
