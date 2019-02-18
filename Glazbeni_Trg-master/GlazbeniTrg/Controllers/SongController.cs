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
using Microsoft.AspNetCore.Authorization;

namespace WebShop.Controllers
{
    [Authorize(Roles = "Admin")]
    public class SongController : Controller
    {
        private readonly ApplicationDbContext _databaseContext;
        private readonly IActionDescriptorCollectionProvider _actionDescriptorCollectionProvider;

        public SongController(ApplicationDbContext context, IActionDescriptorCollectionProvider actionDescriptorCollectionProvider)
        {
            _databaseContext = context;
            _actionDescriptorCollectionProvider = actionDescriptorCollectionProvider;
        }

        public ViewResult Index()
        {
            ViewData["Success"] = TempData["Success"];

            IEnumerable<Song> songs = _databaseContext.Song
               .Include("SongGenres.Genre")
               .Include("SongPersons.Person")
               .Include(s => s.SongPersons).ThenInclude(sp => sp.Person)
               .OrderBy(s => s.SongName)
               .ToList();
            return View(songs);
        }

        public async Task<IActionResult> Show(Guid SongID) => View(await _databaseContext.Song.Include(s => s.SongPersons)
            .ThenInclude(sp => sp.Person).Include("SongGenres.Genre")

                 .SingleOrDefaultAsync(m => m.SongID == SongID));

        [HttpGet]
        public ViewResult Add()
        {
            ViewData["Genres"] = _databaseContext.Genre.ToList();
            //ViewData["Persons"] = _databaseContext.Person.ToList();
            ViewData["Writer"] = _databaseContext.Person.ToList();
            ViewData["Singer"] = _databaseContext.Person.ToList();
            ViewData["Producer"] = _databaseContext.Person.ToList();
            ViewData["Performer"] = _databaseContext.Person.ToList();
            ViewData["Guitarist"] = _databaseContext.Person.ToList();
            ViewData["Drummer"] = _databaseContext.Person.ToList();
            ViewData["Composer"] = _databaseContext.Person.ToList();
            ViewData["Bassist"] = _databaseContext.Person.ToList();

            return View(new SongViewModel());
        }

        [HttpPost]
        public IActionResult Create(SongViewModel model)
        {
            ViewData["Genres"] = _databaseContext.Genre.ToList();
            ViewData["Writer"] = _databaseContext.Person.ToList();
            ViewData["Singer"] = _databaseContext.Person.ToList();
            ViewData["Producer"] = _databaseContext.Person.ToList();
            ViewData["Performer"] = _databaseContext.Person.ToList();
            ViewData["Guitarist"] = _databaseContext.Person.ToList();
            ViewData["Drummer"] = _databaseContext.Person.ToList();
            ViewData["Composer"] = _databaseContext.Person.ToList();
            ViewData["Bassist"] = _databaseContext.Person.ToList();




            if (ModelState.IsValid)
            {
                var songGenres = new List<SongGenre>();
                var songPerson = new List<SongPerson>();
                var song = new Song { SongName = model.SongName, SongYear = model.SongYear, Duration = model.Duration };
                List<SongPerson> osobe = new List<SongPerson>();

                Boolean band = model.Band;

                if (band == true)
                {
                    foreach (Guid id in model.Bassist)
                    {
                        Console.WriteLine("jee" + id);
                        var person = _databaseContext.Person.Find(id);
                        SongPerson sp = new SongPerson { Song = song, Person = person };
                        var per = osobe.Find(x => x.Person.PersonID == person.PersonID);

                        if (per != null)
                        {
                            osobe.Remove(per);
                            per.Function |= Function.BASSIST;
                            osobe.Add(per);
                        }
                        else
                        {
                            sp.Function = Function.BASSIST;
                            osobe.Add(sp);
                        }

                    }

                    foreach (Guid id in model.Drummer)
                    {
                        var person = _databaseContext.Person.Find(id);
                        SongPerson sp = new SongPerson { Song = song, Person = person };
                        var per = osobe.Find(x => x.Person.PersonID == person.PersonID);

                        if (per != null)
                        {
                            osobe.Remove(per);
                            per.Function |= Function.DRUMMER;
                            osobe.Add(per);
                        }
                        else
                        {
                            sp.Function = Function.DRUMMER;
                            osobe.Add(sp);
                        }
                    }

                    foreach (Guid id in model.Guitarist)
                    {
                        var person = _databaseContext.Person.Find(id);
                        SongPerson sp = new SongPerson { Song = song, Person = person };
                        var per = osobe.Find(x => x.Person.PersonID == person.PersonID);

                        if (per != null)
                        {
                            osobe.Remove(per);
                            per.Function |= Function.GUITARIST;
                            osobe.Add(per);
                        }
                        else
                        {
                            sp.Function = Function.GUITARIST;
                            osobe.Add(sp);
                        }
                    }
                    foreach (Guid id in model.Singer)
                    {
                        var person = _databaseContext.Person.Find(id);
                        SongPerson sp = new SongPerson { Song = song, Person = person };
                        var per = osobe.Find(x => x.Person.PersonID == person.PersonID);

                        if (per != null)
                        {
                            osobe.Remove(per);
                            per.Function |= Function.SINGER;
                            osobe.Add(per);
                        }
                        else
                        {
                            sp.Function = Function.SINGER;
                            osobe.Add(sp);
                        }
                    }


                }

                foreach (Guid id in model.GenreIDs)
                {
                    var genre = _databaseContext.Genre.Find(id);
                    song.Genres.Add(genre);
                }

                foreach (Guid id in model.Composer)
                {
                    var person = _databaseContext.Person.Find(id);
                    SongPerson sp = new SongPerson { Song = song, Person = person };
                    var per = osobe.Find(x => x.Person.PersonID == person.PersonID);

                    if (per != null)
                    {
                        osobe.Remove(per);
                        per.Function |= Function.COMPOSER;
                        osobe.Add(per);
                    }
                    else
                    {
                        sp.Function = Function.COMPOSER;
                        osobe.Add(sp);
                    }

                }

                foreach (Guid id in model.Performer)
                {
                    var person = _databaseContext.Person.Find(id);
                    SongPerson sp = new SongPerson { Song = song, Person = person };
                    var per = osobe.Find(x => x.Person.PersonID == person.PersonID);

                    if (per != null)
                    {
                        osobe.Remove(per);
                        per.Function |= Function.PERFORMER;
                        osobe.Add(per);
                    }
                    else
                    {
                        sp.Function = Function.PERFORMER;
                        osobe.Add(sp);
                    }
                }



                foreach (Guid id in model.Producer)
                {
                    var person = _databaseContext.Person.Find(id);
                    SongPerson sp = new SongPerson { Song = song, Person = person };
                    var per = osobe.Find(x => x.Person.PersonID == person.PersonID);

                    if (per != null)
                    {
                        osobe.Remove(per);
                        per.Function |= Function.PRODUCER;
                        osobe.Add(per);
                    }
                    else
                    {
                        sp.Function = Function.PRODUCER;
                        osobe.Add(sp);
                    }
                }

                foreach (Guid id in model.Songwriter)
                {
                    var person = _databaseContext.Person.Find(id);
                    SongPerson sp = new SongPerson { Song = song, Person = person };
                    var per = osobe.Find(x => x.Person.PersonID == person.PersonID);

                    if (per != null)
                    {
                        osobe.Remove(per);
                        per.Function |= Function.SONGWRITER;
                        osobe.Add(per);
                    }
                    else
                    {
                        sp.Function = Function.SONGWRITER;
                        osobe.Add(sp);
                    }
                }

                foreach (var item in osobe)
                {
                    song.SongPersons.Add(item);
                }



                _databaseContext.Song.Add(song);


                TempData["Success"] = true;
                Console.WriteLine(osobe.Count());
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
            var song = _databaseContext.Song.FirstOrDefault(p => p.SongID == id);

            ViewData["Genres"] = _databaseContext.Genre.ToList();
            ViewData["Writer"] = _databaseContext.Person.ToList();
            ViewData["Singer"] = _databaseContext.Person.ToList();
            ViewData["Producer"] = _databaseContext.Person.ToList();
            ViewData["Performer"] = _databaseContext.Person.ToList();
            ViewData["Guitarist"] = _databaseContext.Person.ToList();
            ViewData["Drummer"] = _databaseContext.Person.ToList();
            ViewData["Composer"] = _databaseContext.Person.ToList();
            ViewData["Bassist"] = _databaseContext.Person.ToList();

            Console.WriteLine("pi" + song.SongName);

            Console.WriteLine("li" + song.SongPersons.ToList().Select(u => u.PersonID));
            Console.WriteLine("si" + song.Genres.ToList().Select(gu => gu.GenreID));


            var model = new EditSongViewModel
            {
                Song = song,
                GenreIDs = song.Genres.ToList().Select(gu => gu.GenreID),
                Bassist = song.SongPersons.ToList().Select(u => u.Person.PersonID),
                Composer = song.SongPersons.ToList().Select(u => u.Person.PersonID),
                Drummer = song.SongPersons.ToList().Select(u => u.Person.PersonID),
                Guitarist = song.SongPersons.ToList().Select(u => u.Person.PersonID),
                Performer = song.SongPersons.ToList().Select(u => u.Person.PersonID),
                Producer = song.SongPersons.ToList().Select(u => u.Person.PersonID),
                Singer = song.SongPersons.ToList().Select(u => u.Person.PersonID),
                Songwriter = song.SongPersons.ToList().Select(u => u.Person.PersonID)
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Update(Guid id, EditSongViewModel model)
        {


            if (ModelState.IsValid)
            {
                var song = _databaseContext.Song/*.Include("SongGenres.Genre")/.Include(s=>s.SongPersons).ThenInclude(s=>s.Person)*/
                .FirstOrDefault(m => m.SongID == id);

                Console.WriteLine("songovi" + song.SongPersons.Count());
                Console.WriteLine("ime" + song.SongName);

                song.Duration = model.Song.Duration;
                song.SongName = model.Song.SongName;
                song.SongYear = model.Song.SongYear;

                Boolean band = model.Band;
                List<SongPerson> osobe = new List<SongPerson>();

                TempData["Success"] = true;

                song.Genres.Clear();
                song.SongPersons.Clear();

                var newGenres = _databaseContext.Genre.Where(u => model.GenreIDs.Contains(u.GenreID)).ToList();
                foreach (var genre in newGenres)
                {
                    song.Genres.Add(genre);
                }

                if (band == true)
                {
                    var newBassist = _databaseContext.Person.Where(u => model.Bassist.Contains(u.PersonID)).ToList();
                    Console.WriteLine("broj" + newBassist.Count());
                    var newGuitarist = _databaseContext.Person.Where(u => model.Guitarist.Contains(u.PersonID)).ToList();
                    var newDrummer = _databaseContext.Person.Where(u => model.Drummer.Contains(u.PersonID)).ToList();
                    var newSinger = _databaseContext.Person.Where(u => model.Singer.Contains(u.PersonID)).ToList();

                    foreach (var person in newBassist)
                    {
                        Console.WriteLine("basist" + id);
                        SongPerson sp = new SongPerson { Song = song, Person = person };
                        var per = osobe.Find(x => x.Person.PersonID == person.PersonID);

                        if (per != null)
                        {
                            osobe.Remove(per);
                            per.Function |= Function.BASSIST;
                            osobe.Add(per);
                        }
                        else
                        {
                            sp.Function = Function.BASSIST;
                            osobe.Add(sp);
                        }

                    }

                    foreach (var person in newDrummer)
                    {
                        Console.WriteLine("bubnjar" + id);
                        SongPerson sp = new SongPerson { Song = song, Person = person };
                        var per = osobe.Find(x => x.Person.PersonID == person.PersonID);

                        if (per != null)
                        {
                            osobe.Remove(per);
                            per.Function |= Function.DRUMMER;
                            osobe.Add(per);
                        }
                        else
                        {
                            sp.Function = Function.DRUMMER;
                            osobe.Add(sp);
                        }

                    }

                    foreach (var person in newGuitarist)
                    {
                        Console.WriteLine("gitarist" + id);
                        SongPerson sp = new SongPerson { Song = song, Person = person };
                        var per = osobe.Find(x => x.Person.PersonID == person.PersonID);

                        if (per != null)
                        {
                            osobe.Remove(per);
                            per.Function |= Function.GUITARIST;
                            osobe.Add(per);
                        }
                        else
                        {
                            sp.Function = Function.GUITARIST;
                            osobe.Add(sp);
                        }

                    }
                    foreach (var person in newSinger)
                    {
                        Console.WriteLine("pjevac" + id);
                        SongPerson sp = new SongPerson { Song = song, Person = person };
                        var per = osobe.Find(x => x.Person.PersonID == person.PersonID);

                        if (per != null)
                        {
                            osobe.Remove(per);
                            per.Function |= Function.SINGER;
                            osobe.Add(per);
                        }
                        else
                        {
                            sp.Function = Function.SINGER;
                            osobe.Add(sp);
                        }

                    }
                }

                var newProducer = _databaseContext.Person.Where(u => model.Producer.Contains(u.PersonID)).ToList();
                var newSongWriter = _databaseContext.Person.Where(u => model.Songwriter.Contains(u.PersonID)).ToList();
                var newComposer = _databaseContext.Person.Where(u => model.Composer.Contains(u.PersonID)).ToList();
                var newPerformer = _databaseContext.Person.Where(u => model.Performer.Contains(u.PersonID)).ToList();

                foreach (var person in newProducer)
                {
                    Console.WriteLine("producer" + id);
                    SongPerson sp = new SongPerson { Song = song, Person = person };
                    var per = osobe.Find(x => x.Person.PersonID == person.PersonID);

                    if (per != null)
                    {
                        osobe.Remove(per);
                        per.Function |= Function.PRODUCER;
                        osobe.Add(per);
                    }
                    else
                    {
                        sp.Function = Function.PRODUCER;
                        osobe.Add(sp);
                    }

                }

                foreach (var person in newPerformer)
                {
                    Console.WriteLine("performer" + id);
                    SongPerson sp = new SongPerson { Song = song, Person = person };
                    var per = osobe.Find(x => x.Person.PersonID == person.PersonID);

                    if (per != null)
                    {
                        osobe.Remove(per);
                        per.Function |= Function.PERFORMER;
                        osobe.Add(per);
                    }
                    else
                    {
                        sp.Function = Function.PERFORMER;
                        osobe.Add(sp);
                    }

                }


                foreach (var person in newComposer)
                {
                    Console.WriteLine("composer" + id);
                    SongPerson sp = new SongPerson { Song = song, Person = person };
                    var per = osobe.Find(x => x.Person.PersonID == person.PersonID);

                    if (per != null)
                    {
                        osobe.Remove(per);
                        per.Function |= Function.COMPOSER;
                        osobe.Add(per);
                    }
                    else
                    {
                        sp.Function = Function.COMPOSER;
                        osobe.Add(sp);
                    }

                }

                foreach (var person in newSongWriter)
                {
                    Console.WriteLine("pisac" + id);
                    SongPerson sp = new SongPerson { Song = song, Person = person };
                    var per = osobe.Find(x => x.Person.PersonID == person.PersonID);

                    if (per != null)
                    {
                        osobe.Remove(per);
                        per.Function |= Function.SONGWRITER;
                        osobe.Add(per);
                    }
                    else
                    {
                        sp.Function = Function.SONGWRITER;
                        osobe.Add(sp);
                    }

                }
                song.SongPersons.Clear();
                foreach (var item in osobe)
                {
                    Console.WriteLine("mj" + osobe.Count());

                    song.SongPersons.Add(item);
                }

                _databaseContext.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Delete(Guid id)
        {
            var song = _databaseContext.Song
            .FirstOrDefault(p => p.SongID == id);

            _databaseContext.Song.Remove(song);
            _databaseContext.SaveChanges();
            return RedirectToAction(nameof(Index));
        }



    }
}
