using GlazbeniTrg.Models;
using GlazbeniTrg.Models.ManageViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GlazbeniTrg.Components
{
    public class CartSummary : ViewComponent
    {
        private readonly Cart _cart;
        public CartSummary(Cart cart)
        {
            _cart = cart;
        }
        public IViewComponentResult Invoke()
        {
            var items = _cart.GetCartAlbums();
            _cart.CartAlbums = items;

            var cartViewModel = new CartViewModel
            {
                Cart = _cart,
                CartTotal = _cart.getCartTotal()
            };
            return View(cartViewModel);
        }
    }
}
