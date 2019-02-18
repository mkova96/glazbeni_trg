using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GlazbeniTrg.Models.ViewModels
{
    public class AlbumViewModel
    {
        [Required]
        [StringLength(100, ErrorMessage = "Ime mora biti kraće od 100 znakova!")]
        public string AlbumName { get; set; }


        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy}", ApplyFormatInEditMode = true)]
        public DateTime AlbumYear { get; set; }

        public Media Format { get; set; }

        [Range(0, 10000)]
        public int Stock { get; set; }

        [Required]
        [Range(0, 10000)]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [Range(0, 5)]
        public decimal AvgGrade { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Required]
        [DataType(DataType.ImageUrl)]
        public string ImagePath { get; set; }

        public virtual Guid LabelID { get; set; }

        [Required]
        [MinLength(1)]
        public List<Guid> GenreIDs { get; set; }

        [Required]
        [MinLength(1)]
        public List<Guid> SongIDs { get; set; }
    }
}