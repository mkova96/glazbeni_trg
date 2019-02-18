using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace GlazbeniTrg.Models
{
    public class CartAlbum 
    {
        public Guid CartAlbumID { get; set; }
        public Guid CartID { get; set; }
        
        public Album Album { get; set; }

        [Required]
        public int quantity { get; set; }

        
        

    }
}
