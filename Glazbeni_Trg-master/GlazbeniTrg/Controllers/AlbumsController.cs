using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GlazbeniTrg.Data;
using GlazbeniTrg.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace GlazbeniTrg.Controllers
{
    public class AlbumsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public AlbumsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Albums
        public async Task<IActionResult> Index(string searchString, string sort, string[] genress, string minPrice, string maxPrice, string yearMin, string yearMax)
        {
            ViewData["CurrentFilter"] = searchString;
            ViewData["DateSortParm"] = sort;
            ViewData["MinPrice"] = minPrice;
            ViewData["MaxPrice"] = maxPrice;
            ViewData["YearMin"] = yearMin;
            ViewData["YearMax"] = yearMax;
            ViewData["Filteri"] = genress;


            List<String> sortList = new List<String>();
            sortList.Add("abecedno");
            sortList.Add("po cijeni uzlazno");
            sortList.Add("po cijeni silazno");
            sortList.Add("po ocjeni");
            ViewBag.DropDownCollection = new SelectList(sortList);


            var applicationDbContext = _context.Album.Include(a => a.Label).Include(a => a.Songs).ThenInclude(s => s.SongPersons).ThenInclude(sp => sp.Person).Include("AlbumGenres.Genre");
            HashSet<Album> albums = applicationDbContext.ToHashSet();
            
            var albums1 = new HashSet<Album>();
            if (!String.IsNullOrEmpty(searchString))
            {

                albums = applicationDbContext.Where(a => a.AlbumName.Contains(searchString) || a.Songs.Any(s => s.SongName.Contains(searchString))).Include(a => a.Songs).ThenInclude(d => d.SongPersons).ThenInclude(sp => sp.Person).ToHashSet();
                var son = _context.SongPerson.Where(sp => (sp.Person.FirstName.Contains(searchString) || sp.Person.LastName.Contains(searchString)) && sp.Function == Function.PERFORMER).Select(sp => sp.Song).Include(k => k.SongPersons).ThenInclude(sp => sp.Person).ToList();

                foreach (var s in son)
                {
                    foreach (var am in _context.Album.Include(shj => shj.Songs).ThenInclude(g => g.SongPersons).ThenInclude(sp => sp.Person).ToList())
                    {
                        if (am.Songs.Contains(s))
                        {
                            albums1.Add(am);
                        }
                    }
                }

                foreach (var i in albums1)
                {
                    albums.Add(i);
                }
            }
            if (!String.IsNullOrEmpty(maxPrice)) {
                albums.RemoveWhere(a => a.Price > decimal.Parse(maxPrice));
            }
            if (!String.IsNullOrEmpty(minPrice))
            {
                albums.RemoveWhere(a => a.Price < decimal.Parse(minPrice));
            }
            if (!String.IsNullOrEmpty(yearMax))
            {
                albums.RemoveWhere(a => a.AlbumYear.Year > new DateTime(int.Parse(yearMax),1,1,0,0,0).Year);
            }
            if (!String.IsNullOrEmpty(yearMin))
            {
                albums.RemoveWhere(a => a.AlbumYear.Year < new DateTime(int.Parse(yearMin),1,1,0,0,0).Year);
            }
            if (genress.Length != 0)
            {
                HashSet<Album> ba = new HashSet<Album>();
                foreach(var i in albums)
                {
                    ba.Add(i);
                }
                foreach(var e in albums)
                {
                    int check = 0;

                    foreach(var p in genress)
                    {
                        if (e.Genres.Any(g=>g.GenreName.Equals(p)))
                        {
                            check = 1;
                        }
                    }
                    if (check == 0)
                    {
                        ba.Remove(e);
                    }
                }
                albums = ba;
            }
          

            switch (sort)
            {
                case "abecedno":
                    return View(albums.OrderBy(a => a.AlbumName));
                case "po cijeni uzlazno":
                    return View(albums.OrderBy(a => a.Price));

                case "po cijeni silazno":
                    return View(albums.OrderByDescending(a => a.Price));
                case "po ocjeni":
                    return View(albums.OrderByDescending(a => a.AvgGrade));
                default:
                    return View(albums.OrderBy(a => a.AlbumName));
            }
            

        }

        // GET: Albums/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var album = await _context.Album.Include(a => a.Songs).ThenInclude(s => s.SongPersons).ThenInclude(sp => sp.Person).Include("AlbumGenres.Genre")
                .Include(a => a.Label)
                .SingleOrDefaultAsync(m => m.AlbumID == id);
            if (album == null)
            {
                return NotFound();
            }

            return View(album);
        }
        // GET: Albums/Create
        public IActionResult Create()
        {
            ViewData["LabelID"] = new SelectList(_context.Label, "LabelID", "LabelName");
            return View();
        }

        // POST: Albums/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AlbumID,AlbumName,AlbumYear,Format,Stock,Price,AvgGrade,Description,ImagePath,LabelID")] Album album)
        {
            if (ModelState.IsValid)
            {
                album.AlbumID = Guid.NewGuid();
                _context.Add(album);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["LabelID"] = new SelectList(_context.Label, "LabelID", "LabelName", album.LabelID);
            return View(album);
        }

        // GET: Albums/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var album = await _context.Album.SingleOrDefaultAsync(m => m.AlbumID == id);
            if (album == null)
            {
                return NotFound();
            }
            ViewData["LabelID"] = new SelectList(_context.Label, "LabelID", "LabelName", album.LabelID);
            return View(album);
        }

        // POST: Albums/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("AlbumID,AlbumName,AlbumYear,Format,Stock,Price,AvgGrade,Description,ImagePath,LabelID")] Album album)
        {
            if (id != album.AlbumID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(album);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AlbumExists(album.AlbumID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["LabelID"] = new SelectList(_context.Label, "LabelID", "LabelName", album.LabelID);
            return View(album);
        }

        // GET: Albums/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var album = await _context.Album
                .Include(a => a.Label)
                .SingleOrDefaultAsync(m => m.AlbumID == id);
            if (album == null)
            {
                return NotFound();
            }

            return View(album);
        }

        // POST: Albums/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var album = await _context.Album.SingleOrDefaultAsync(m => m.AlbumID == id);
            _context.Album.Remove(album);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AlbumExists(Guid id)
        {
            return _context.Album.Any(e => e.AlbumID == id);
        }


        public async Task<IActionResult> Rate(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var album = await _context.Album.SingleOrDefaultAsync(m => m.AlbumID == id);
            if (album == null)
            {
                return NotFound();
            }
            return View(album);
        }

        [HttpPost]
        public async Task<ActionResult> SaveRate(String AlbumId, IFormCollection fc)
        {

            if (AlbumId == null)
            {
                return NotFound();
            }


            var album = await _context.Album.SingleOrDefaultAsync(m => m.AlbumID.ToString().Equals(AlbumId));
            if (album == null)
            {
                return NotFound();
            }
            int radio = Convert.ToInt32(fc["rate"]);
            var user = await GetCurrentUserAsync();
            var userId = user?.Id;

            var exist = _context.Rating.Where(m => m.AlbumID.ToString().Equals(AlbumId)).Where(i => i.Id == userId);

            if (!exist.Any())
            {
                Rating rating = new Rating { AlbumID = album.AlbumID, Album = album, Id = userId, ApplicationUser = user, Grade = radio, GradeDate = DateTime.Now };
                _context.Rating.AddRange(rating);
                _context.SaveChanges();
            }
            else
            {
                Rating existing = _context.Rating.Where(m => m.AlbumID.ToString().Equals(AlbumId)).Where(i => i.Id == userId).First();
                existing.Grade = radio;
            }
            List<Rating> ratings = await _context.Rating.Where(a => a.AlbumID == album.AlbumID).ToListAsync();
            int number = ratings.Count;
            decimal counter = 0;
            foreach (Rating r in ratings)
            {
                counter = counter + r.Grade;

            }
            album.AvgGrade = counter / number;
            _context.SaveChanges();
            return View(album);
        }
        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);

    }
}
