using csharp_boolflix.Data;
using csharp_boolflix.Models.Form;
using csharp_boolflix.Models.Repository;
using csharp_boolflix.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace csharp_boolflix.Controllers
{
    [Authorize]
    //[Route("[controller]/[action]/{id?}", Order = 0)]
    public class SerieController : Controller
    {
        BoolflixDbContext db;
        IContentRepository contentRepository;

        public SerieController(IContentRepository _contentRepository, BoolflixDbContext _db)
        {
            db = _db;
            contentRepository = _contentRepository;
        }

        public IActionResult Index()
        {
            List<Serie> listSerie = contentRepository.AllSeries();
            return View(listSerie);
        }

        public IActionResult Create()
        {
            FormSerie formData = new FormSerie();
            formData.Serie = new Serie();
            formData.Directors = db.Directors.ToList();

            formData.Actors = new List<SelectListItem>();
            List<Actor> actorsList = db.Actors.ToList();
            foreach (Actor actor in actorsList)
            {
                formData.Actors.Add(new SelectListItem(actor.Name, actor.Id.ToString()));
            }

            formData.Categories = new List<SelectListItem>();
            List<Category> categoryList = db.Categories.ToList();
            foreach (Category category in categoryList)
            {
                formData.Categories.Add(new SelectListItem(category.Name, category.Id.ToString()));
            }

            return View(formData);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(FormSerie formData)
        {
            if (!ModelState.IsValid)
            {
                formData.Directors = db.Directors.ToList();

                formData.Actors = new List<SelectListItem>();
                List<Actor> actorsList = db.Actors.ToList();
                foreach (Actor actor in actorsList)
                {
                    formData.Actors.Add(new SelectListItem(actor.Name, actor.Id.ToString()));
                }

                formData.Categories = new List<SelectListItem>();
                List<Category> categoryList = db.Categories.ToList();
                foreach (Category category in categoryList)
                {
                    formData.Categories.Add(new SelectListItem(category.Name, category.Id.ToString()));
                }

                return View(formData);

            }

            Director director = db.Directors.Where(d => d.Id == formData.Serie.DirectorId).FirstOrDefault();

            contentRepository.CreateSerie(formData.Serie, formData.SelectedCategories, formData.SelectedActors);

            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            Serie serie = contentRepository.GetSerieById(id);

            return View(serie);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            Serie serie = contentRepository.GetSerieById(id);
            if (serie == null)
            {
                return NotFound();
            }

            contentRepository.DeleteSerie(serie);

            return RedirectToAction("Index");
        }

        public IActionResult AddSeason(int id)
        {
            Season season = new Season();
            season.SerieId = id;
            return View(season);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddSeason(Season season, int id)
        {
            season.Id = 0;
            season.SerieId = id;
            if (!ModelState.IsValid)
            {
                return View(season);
            }
            contentRepository.CreateSeason(season);
            return RedirectToAction("Detail", new { id = season.SerieId });
        }
    }
}
