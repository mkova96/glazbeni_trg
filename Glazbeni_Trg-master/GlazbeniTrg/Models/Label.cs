using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GlazbeniTrg.Models
{
    public class Label
    {
        [Key]
        public Guid LabelID { get; set; }

        [Required]
        [StringLength(100)]
        public String LabelName { get; set; }

        public virtual ICollection<Album> Albums { get; set; }
    }
}
