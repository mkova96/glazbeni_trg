using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GlazbeniTrg.Models.ViewModels
{
    public class LabelViewModel
    {
        [Required]
        [StringLength(100)]
        public string LabelName
        {
            get;
            set;
        }

    }
}