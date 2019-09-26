using MovieRental.Models;
using MovieRental.ViewModels;
using System;
using System.Linq;
using System.Web.Mvc;

namespace MovieRental.Controllers
{
    public class DocumentariesController : Controller
    {
        private ApplicationDbContext _context;

        public DocumentariesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // Documentaries
        public ActionResult Index()
        {
            if (User.IsInRole(RoleName.CanManageMovies))
                return View("List");

            return View("ReadOnlyList");
        }

        // Documentaries/New
        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult New()
        {
            var genres = _context.DocumentaryGenres.ToList();
            var viewModel = new DocumentariesFormViewModel
            {
                Genres = genres
            };
            return View("DocumentariesForm", viewModel);
        }

        // Documentaries/Edit
        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult Edit(int id)
        {
            var documentary = _context.Documentaries.SingleOrDefault(d => d.Id == id);
            if (documentary == null)
                return HttpNotFound();

            var viewModel = new DocumentariesFormViewModel(documentary)
            {
                Genres = _context.DocumentaryGenres.ToList()
            };
            return View("DocumentariesForm", viewModel);
        }

        [HttpPost]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult Save(Documentary documentary)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new DocumentariesFormViewModel(documentary)
                {
                    Genres = _context.DocumentaryGenres.ToList()
                };
                return View("DocumentariesForm", viewModel);
            }

            if (documentary.Id == 0)
            {
                documentary.DateAdded = DateTime.Now;
                _context.Documentaries.Add(documentary);
            }
            else
            {
                var documentaryInDb = _context.Documentaries.Single(d => d.Id == documentary.Id);
                documentaryInDb.Name = documentary.Name;
                documentaryInDb.ReleaseDate = documentary.ReleaseDate;
                documentaryInDb.NumberInStock = documentary.NumberInStock;
                documentaryInDb.DocumentaryGenreId = documentary.DocumentaryGenreId;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Documentaries");
        }

        // Documentaries/Details/id
        public ActionResult Details(int id)
        {
            var documentaries = _context.Documentaries.SingleOrDefault(d => d.Id == id);
            if (documentaries == null)
                return HttpNotFound();

            return View(documentaries);
        }


    }
}