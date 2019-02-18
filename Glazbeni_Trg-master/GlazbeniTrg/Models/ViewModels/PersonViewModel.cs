using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GlazbeniTrg.Models.ViewModels
{
    public class PersonViewModel
    {
        [Required]
        [StringLength(100)]
        public string FirstName
        {
            get;
            set;
        }

        [Required]
        [StringLength(100)]
        public string LastName
        {
            get;
            set;
        }

        [DataType(DataType.MultilineText)]
        public string Bio
        {
            get;
            set;
        }
    }
}
