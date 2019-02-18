using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using GlazbeniTrg.Models;
using GlazbeniTrg.Models.ViewModels;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using GlazbeniTrg.Data;
using Microsoft.AspNetCore.Authorization;

namespace WebShop.Controllers
{
    [Authorize(Roles = "Admin")]
    public class LabelController : Controller
    {
        private readonly ApplicationDbContext _databaseContext;
        private readonly IActionDescriptorCollectionProvider _actionDescriptorCollectionProvider;

        public LabelController(ApplicationDbContext context, IActionDescriptorCollectionProvider actionDescriptorCollectionProvider)
        {
            _databaseContext = context;
            _actionDescriptorCollectionProvider = actionDescriptorCollectionProvider;
        }

        public ViewResult Index()
        {
            ViewData["Success"] = TempData["Success"];
            IEnumerable<Label> labels = _databaseContext.Label.ToList();
            return View(labels);
        }

        [HttpGet]
        public ViewResult Add()
        {
            return View(new LabelViewModel());
        }

        [HttpPost]
        public IActionResult Create(LabelViewModel model)
        {
            if (ModelState.IsValid)
            {
                var label = new Label { LabelName = model.LabelName };
                _databaseContext.Label.Add(label);


                TempData["Success"] = true;
                _databaseContext.SaveChanges();
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Delete(Guid id)
        {
            var label = _databaseContext.Label
            .FirstOrDefault(p => p.LabelID == id);

            _databaseContext.Label.Remove(label);
            _databaseContext.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public ViewResult Edit(Guid id)
        {
            var label = _databaseContext.Label
            .FirstOrDefault(p => p.LabelID == id);

            ViewData["Success"] = TempData["Success"];

            var model = new EditLabelViewModel
            {
                Label = label
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Update(Guid id, EditLabelViewModel model)
        {


            if (ModelState.IsValid)
            {
                var label = _databaseContext.Label

                .FirstOrDefault(m => m.LabelID == id);

                label.LabelName = model.Label.LabelName;

                TempData["Success"] = true;


                _databaseContext.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }


    }
}
