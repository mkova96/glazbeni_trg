using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using GlazbeniTrg.Models;
using GlazbeniTrg.Views;
using GlazbeniTrg.Data;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebShop.Controllers
{
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _databaseContext;
        private readonly IActionDescriptorCollectionProvider _actionDescriptorCollectionProvider;

        public UserController(ApplicationDbContext context, IActionDescriptorCollectionProvider actionDescriptorCollectionProvider)
        {
            _databaseContext = context;
            _actionDescriptorCollectionProvider = actionDescriptorCollectionProvider;
        }

        public ViewResult Index()
        {
            ViewData["Success"] = TempData["Success"];

            IEnumerable<ApplicationUser> users = _databaseContext
                .ApplicationUser
                .Include(u => u.City).ThenInclude(u => u.Country)
                .ToList();
            return View(users);
        }
        public ViewResult Show(String ID) => View(_databaseContext
           .ApplicationUser
           .Include(u => u.City).ThenInclude(u => u.Country)
           .FirstOrDefault(p => p.Id == ID));

        [HttpPost]
        public IActionResult Delete(String id)
        {
            var user = _databaseContext.ApplicationUser
            .FirstOrDefault(p => p.Id == id);

            _databaseContext.ApplicationUser.Remove(user);
            _databaseContext.SaveChanges();
            return RedirectToAction(nameof(Index));
        }


    }
}
