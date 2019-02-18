using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GlazbeniTrg.Models.ViewModels
{
    public class SongViewModel
    {
        [Required]
        [StringLength(100)]
        public string SongName
        {
            get;
            set;
        }

        [DataType(DataType.Duration)]
        public TimeSpan Duration
        {
            get;
            set;
        }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy}", ApplyFormatInEditMode = true)]
        public DateTime SongYear
        {
            get;
            set;
        }


        public List<Guid> GenreIDs { get; set; }

        public List<Guid> Producer { get; set; }
        public List<Guid> Performer { get; set; }
        public List<Guid> Composer { get; set; }
        public List<Guid> Songwriter { get; set; }
        public List<Guid> Singer { get; set; }
        public List<Guid> Drummer { get; set; }
        public List<Guid> Bassist { get; set; }
        public List<Guid> Guitarist { get; set; }

        public Boolean Band { get; set; }


    }
}
