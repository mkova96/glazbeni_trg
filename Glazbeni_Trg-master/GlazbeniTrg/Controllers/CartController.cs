using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GlazbeniTrg.Models;
using GlazbeniTrg.Models.ManageViewModels;
using GlazbeniTrg.Data;

namespace GlazbeniTrg.Controllers
{
    public class CartController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly Cart _cart;
        public CartController(Cart cart, ApplicationDbContext context)
        {
            _cart = cart;
            _context = context;
        }
       
        public ViewResult Index()
        {
            var items = _cart.GetCartAlbums();
            _cart.CartAlbums = items;

            var cVM = new CartViewModel
            {
                Cart = _cart,
                CartTotal = _cart.getCartTotal()

            };
            return View(cVM);
        }
        public RedirectToActionResult AddToCart(Guid albumId)
        {
            var selected = _context.Album.FirstOrDefault(p => p.AlbumID == albumId);
            if (selected != null)
            {
                _cart.AddToCart(selected,1);
            }
            return RedirectToAction("Index");
        }
        public RedirectToActionResult RemoveFromCart (Guid albumId)
        {
            var selected = _context.Album.FirstOrDefault(p => p.AlbumID == albumId);
            if (selected != null)
            {
                _cart.RemoveFromCart(selected);
            }
            return RedirectToAction("Index");
        }
    }
}
