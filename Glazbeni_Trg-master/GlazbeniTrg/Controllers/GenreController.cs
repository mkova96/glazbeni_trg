using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GlazbeniTrg.Models;
using GlazbeniTrg.Data;
using GlazbeniTrg.Models.ViewModels;
using System;
using Microsoft.AspNetCore.Authorization;

namespace GlazbeniTrg.Controllers
{
    [Authorize(Roles = "Admin")]
    public class GenreController : Controller
    {
        private readonly ApplicationDbContext _databaseContext;

        public GenreController(ApplicationDbContext context)
        {
            _databaseContext = context;
        }

        public ViewResult Index()
        {
            ViewData["Success"] = TempData["Success"];
            IEnumerable<Genre> genres = _databaseContext
                .Genre
                .ToList();
            return View(genres);
        }

        [HttpGet]
        public ViewResult Add()
        {
            return View(new GenreViewModel());
        }

        [HttpPost]
        public IActionResult Create(GenreViewModel model)
        {
            if (ModelState.IsValid)
            {
                var genre = new Genre { GenreName = model.GenreName };
                _databaseContext.Genre.Add(genre);

                TempData["Success"] = true;
                _databaseContext.SaveChanges();
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Delete(Guid id)
        {
            var genre = _databaseContext.Genre
            .FirstOrDefault(p => p.GenreID == id);

            if (genre.Albums.Count() > 0)
            {
                ViewBag.Message = "Žanr ne može biti obrisan";

            }
            else
            {
                _databaseContext.Genre.Remove(genre);
                _databaseContext.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public ViewResult Edit(Guid id)
        {
            var genre = _databaseContext.Genre
            .FirstOrDefault(p => p.GenreID == id);

            ViewData["Success"] = TempData["Success"];

            var model = new EditGenreViewModel
            {
                Genre = genre
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Update(Guid id, EditGenreViewModel model)
        {


            if (ModelState.IsValid)
            {
                var genre = _databaseContext.Genre

                .FirstOrDefault(m => m.GenreID == id);

                genre.GenreName = model.Genre.GenreName;

                TempData["Success"] = true;


                _databaseContext.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }

    }
}