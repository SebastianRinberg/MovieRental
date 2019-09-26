using MovieRental.Models;
using MovieRental.ViewModels;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace MovieRental.Controllers
{
    public class SeriesController : Controller
    {

        private ApplicationDbContext _context;
        public SeriesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // Series
        public ActionResult Index()
        {
            if (User.IsInRole(RoleName.CanManageMovies))
                return View("List");

            return View("ReadOnlyList");
        }


        // Series/New
        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult New()
        {
            var genres = _context.Genres.ToList();
            var viewModel = new SeriesFormViewModel
            {
                Genres = genres
            };
            return View("SeriesForm", viewModel);
        }


        // Series/Edit
        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult Edit(int id)
        {
            var series = _context.Series.SingleOrDefault(s => s.Id == id);
            if (series == null)
                return HttpNotFound();

            var viewModel = new SeriesFormViewModel(series)
            {
                Genres = _context.Genres
            };
            return View("SeriesForm", viewModel);
        }

        // Create And Update series
        [HttpPost]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult Save(Series series)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new SeriesFormViewModel(series)
                {
                    Genres = _context.Genres.ToList()
                };
                return View("SeriesForm", viewModel);
            }

            if (series.Id == 0)
            {
                series.DateAdded = DateTime.Now;
                _context.Series.Add(series);
            }
            else
            {
                var seriesInDb = _context.Series.Single(s => s.Id == series.Id);

                seriesInDb.Name = series.Name;
                seriesInDb.Season = series.Season;
                seriesInDb.ReleaseDate = series.ReleaseDate;
                seriesInDb.NumberInStock = series.NumberInStock;
                seriesInDb.GenreId = series.GenreId;
            }
            return RedirectToAction("Index", "Series");
        }




        // Series /Details
        public ActionResult Details(int id)
        {
            var series = _context.Series.Include(s => s.Genre).SingleOrDefault(s => s.Id == id);
            if (series == null)
                return HttpNotFound();

            return View(series);
        }
    }
}