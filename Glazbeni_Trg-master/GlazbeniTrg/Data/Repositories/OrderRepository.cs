using GlazbeniTrg.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GlazbeniTrg.Models;
using Microsoft.AspNetCore.Identity;

namespace GlazbeniTrg.Data.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly Cart _cart;


        public OrderRepository(ApplicationDbContext applicationDbContext, Cart cart)
        {
            _applicationDbContext = applicationDbContext;
            _cart = cart;

        }

        public void CreateOrder(Order order, string userId)
        {
            order.OrderDate = DateTime.Now;
            order.UserId = userId;
            order.PriceSum = _cart.getCartTotal();
            _applicationDbContext.Order.Add(order);


            var cartItems = _cart.CartAlbums;

            foreach (var item in cartItems)
            {
                var orderDetail = new OrderDetail()
                {
                    Amount = item.quantity,
                    AlbumId=item.Album.AlbumID,
                    OrderID=order.OrderID,
                    Price=item.Album.Price,
                };
                _applicationDbContext.OrderDetail.Add(orderDetail);
            }
            _applicationDbContext.SaveChanges();
        }
    }
}
