using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using GlazbeniTrg.Models;
using GlazbeniTrg.Models.ViewModels;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using GlazbeniTrg.Data;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;

namespace GlazbeniTrg.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AlbumController : Controller
    {
        private readonly ApplicationDbContext _databaseContext;
        private readonly IActionDescriptorCollectionProvider _actionDescriptorCollectionProvider;

        public AlbumController(ApplicationDbContext context, IActionDescriptorCollectionProvider actionDescriptorCollectionProvider)
        {
            _databaseContext = context;
            _actionDescriptorCollectionProvider = actionDescriptorCollectionProvider;
        }

        public ViewResult Index()
        {
            ViewData["Success"] = TempData["Success"];

            IEnumerable<Album> albums = _databaseContext.Album.Include(a => a.Label).Include(a => a.Songs).ThenInclude(s => s.SongPersons).ThenInclude(sp => sp.Person).Include("AlbumGenres.Genre")
                .Include(a => a.Label)
               .ToList();

            return View(albums);
        }

        public async Task<IActionResult> Show(Guid AlbumID) => View(await _databaseContext.Album.Include(a => a.Songs).ThenInclude(s => s.SongPersons).ThenInclude(sp => sp.Person).Include("AlbumGenres.Genre")
                .Include(a => a.Label)
                .SingleOrDefaultAsync(m => m.AlbumID == AlbumID));

        [HttpGet]
        public ViewResult Add()
        {
            ViewData["Genres"] = _databaseContext.Genre.ToList();
            ViewData["Labels"] = _databaseContext.Label.ToList();
            ViewData["Songs"] = _databaseContext.Song.ToList();
            return View(new AlbumViewModel());
        }


        [HttpPost]
        public IActionResult Create(AlbumViewModel model)
        {
            ViewData["Genres"] = _databaseContext.Genre.ToList();
            ViewData["Labels"] = _databaseContext.Label.ToList();
            ViewData["Songs"] = _databaseContext.Song.ToList();

            if (ModelState.IsValid)
            {
                var label = _databaseContext.Label.FirstOrDefault(m => m.LabelID == model.LabelID);
                var albumGenres = new List<AlbumGenre>();
                var albumSongs = new List<SongAlbum>();

                var album = new Album
                {
                    AlbumName = model.AlbumName,
                    AlbumYear = model.AlbumYear,
                    AvgGrade = model.AvgGrade,
                    Description = model.Description,
                    Format = model.Format,
                    ImagePath = model.ImagePath,
                    Price = model.Price,
                    Stock = model.Stock,
                    Label = label
                };

                foreach (Guid id in model.GenreIDs)
                {
                    var genre = _databaseContext.Genre.Find(id); //pazi
                    album.Genres.Add(genre);
                }
                foreach (Guid id in model.SongIDs)
                {
                    var song = _databaseContext.Song.Find(id); //pazi
                    album.Songs.Add(song);
                }

                _databaseContext.Album.Add(album);

                TempData["Success"] = true;
                _databaseContext.SaveChanges();
            }
            else
            {
                return View("Add", model);
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public ViewResult Edit(Guid id)
        {
            var album = _databaseContext.Album.Include(a => a.Songs)
               //.ThenInclude(s => s.SongPersons)
               //.ThenInclude(sp => sp.Person)
               //.Include("AlbumGenres.Genre")
               //.Include(a => a.Label)
               .FirstOrDefault(m => m.AlbumID == id);

            Console.WriteLine("evo" + album.AlbumName);

            ViewData["Success"] = TempData["Success"];
            ViewData["Labels"] = _databaseContext.Label.ToList();
            ViewData["Genres"] = _databaseContext.Genre.ToList();
            ViewData["Songs"] = _databaseContext.Song.ToList();

            var model = new EditAlbumViewModel
            {
                Album = album,
                LabelID = album.Label.LabelID,
                GenreIDs = album.Genres.ToList().Select(gu => gu.GenreID),
                SongIDs = album.Songs.ToList().Select(mu => mu.SongID)
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Update(Guid id, EditAlbumViewModel model)
        {


            if (ModelState.IsValid)
            {
                var album = _databaseContext.Album
               .Include("AlbumGenres.Genre")
               .Include("SongAlbums.Song.SongGenres.Genre")
                .FirstOrDefault(m => m.AlbumID == id);


                album.Label = _databaseContext.Label.ToList().First(c => c.LabelID == model.LabelID);
                album.AlbumName = model.Album.AlbumName;
                album.AlbumYear = model.Album.AlbumYear;
                album.Description = model.Album.Description;
                album.AvgGrade = model.Album.AvgGrade;
                album.Format = model.Album.Format;
                album.ImagePath = model.Album.ImagePath;
                album.Price = model.Album.Price;
                album.Stock = model.Album.Stock;

                foreach (Guid ID in model.GenreIDs)
                {
                    var genre = _databaseContext.Genre.Find(ID);
                    album.Genres.Add(genre);
                }
                foreach (Guid ID in model.SongIDs)
                {
                    var song = _databaseContext.Song.Find(ID);
                    album.Songs.Add(song);
                }


                TempData["Success"] = true;

                album.Genres.Clear();
                album.Songs.Clear();

                var newGenres = _databaseContext.Genre.Where(u => model.GenreIDs.Contains(u.GenreID)).ToList();
                foreach (var genre in newGenres)
                {
                    album.Genres.Add(genre);
                }

                var newSongs = _databaseContext.Song.Where(u => model.SongIDs.Contains(u.SongID)).ToList();
                foreach (var song in newSongs)
                {
                    album.Songs.Add(song);
                }


                _databaseContext.SaveChanges();
            }
            return Redirect(nameof(Index));
        }


        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var album = await _databaseContext.Album
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
            var album = await _databaseContext.Album.SingleOrDefaultAsync(m => m.AlbumID == id);
            var songs = _databaseContext.Album.FirstOrDefault(a => a.AlbumID == id).Songs.ToList();
            foreach (var s in songs)
            {
                if (album.Songs.Contains(s))
                {
                    album.Songs.Remove(s);
                }
                
                if (s.Albums.Contains(album))
                {
                    s.Albums.Remove(album);
                }
                
            }


            _databaseContext.Album.Remove(album);
            await _databaseContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}

