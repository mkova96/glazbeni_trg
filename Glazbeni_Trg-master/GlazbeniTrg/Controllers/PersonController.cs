using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GlazbeniTrg.Models;
using GlazbeniTrg.Models.ViewModels;
using System;
using GlazbeniTrg.Data;
using Microsoft.AspNetCore.Authorization;

namespace Sup.Controllers
{
    [Authorize(Roles = "Admin")]
    public class PersonController : Controller
    {
        private readonly ApplicationDbContext _databaseContext;

        public PersonController(ApplicationDbContext context)
        {
            _databaseContext = context;
        }

        public ViewResult Index()
        {
            ViewData["Success"] = TempData["Success"];
            IEnumerable<Person> persons = _databaseContext
                .Person
                .ToList();
            return View(persons);
        }

        [HttpGet]
        public ViewResult Add()
        {
            return View(new PersonViewModel());
        }

        [HttpPost]
        public IActionResult Create(PersonViewModel model)
        {
            if (ModelState.IsValid)
            {
                var person = new Person { FirstName = model.FirstName, LastName = model.LastName, Bio = model.Bio };
                _databaseContext.Person.Add(person);

                TempData["Success"] = true;
                _databaseContext.SaveChanges();
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public ViewResult Edit(Guid id)
        {
            var person = _databaseContext.Person
            .FirstOrDefault(p => p.PersonID == id);

            ViewData["Success"] = TempData["Success"];

            var model = new EditPersonViewModel
            {
                Person = person
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Update(Guid id, EditPersonViewModel model)
        {


            if (ModelState.IsValid)
            {
                var person = _databaseContext.Person

                .FirstOrDefault(m => m.PersonID == id);

                person.FirstName = model.Person.FirstName;
                person.LastName = model.Person.LastName;
                person.Bio = model.Person.Bio;

                TempData["Success"] = true;


                _databaseContext.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }

        public ViewResult Show(Guid PersonID) => View(_databaseContext.
         Person.FirstOrDefault(p => p.PersonID == PersonID));

        [HttpPost]
        public IActionResult Delete(Guid id)
        {
            var person = _databaseContext.Person
            .FirstOrDefault(p => p.PersonID == id);

            _databaseContext.Person.Remove(person);
            _databaseContext.SaveChanges();
            return RedirectToAction(nameof(Index));
        }



    }
}