using GlazbeniTrg.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GlazbeniTrg.Data.Interfaces
{
    public interface IOrderRepository
    {
        void CreateOrder(Order order, string userId);
    }
}
