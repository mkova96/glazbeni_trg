using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GlazbeniTrg.Models
{
    public class OrderDetail
    {
        public Guid OrderDetailId { get; set; }

        public Guid OrderID { get; set; }
        public virtual Order Order { get; set; }

        public Guid AlbumId { get; set; }
        public virtual Album Album { get; set; }

        public int Amount { get; set; }

        public decimal Price { get; set; }
    }
}
