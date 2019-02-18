using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GlazbeniTrg.Data.Interfaces;
using GlazbeniTrg.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using GlazbeniTrg.Data.Repositories;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GlazbeniTrg.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderRepository _orderRepository;
        private readonly Cart _cart;
        private readonly UserManager<ApplicationUser> _userManager;

        public OrderController(IOrderRepository orderRepository, Cart cart, UserManager<ApplicationUser> userManager)
        {
            _orderRepository = orderRepository;
            _cart = cart;
            _userManager = userManager;
        }
        [Authorize]
        public IActionResult Checkout()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public IActionResult Checkout(Order order)
        {
            var items = _cart.GetCartAlbums();
            _cart.CartAlbums = items;
            if (_cart.CartAlbums.Count == 0)
            {
                ModelState.AddModelError("", "Vaša košarica je prazna!");
            }

            if (ModelState.IsValid)
            {
                _orderRepository.CreateOrder(order, _userManager.GetUserId(User));
                _cart.ClearCart();
                return RedirectToAction("CheckoutComplete");
            }

            return View(order);
        }

        public IActionResult CheckoutComplete()
        {
            ViewBag.CheckoutCompleteMessage = "Hvala Vam na kupovini :) ";
            return View();
        }
    }
}
