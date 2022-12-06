using csharp_boolflix.Data;
using csharp_boolflix.Models;
using csharp_boolflix.Models.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace csharp_boolflix.Controllers
{
    [Authorize]
    [Route("[controller]/[action]/{id?}", Order = 0)]
    public class FilmController : Controller
    {
        BoolflixDbContext db;
        IContentRepository contentRepository;
        
        public FilmController(IContentRepository _contentRepository, BoolflixDbContext _db)
        {
            db = _db;
            contentRepository = _contentRepository;
        }

        public IActionResult Index()
        {
            List <Film> listFilm = contentRepository.AllFilms();
            return View(listFilm);
        }

        public IActionResult Create()
        {
            ContentForm formData = new ContentForm();
            formData.Film = new Film();
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
        public IActionResult CreateFilm(ContentForm formData)
        {
            if (!ModelState.IsValid)
            {               

                return View(formData);
            }

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

            Director director = db.Directors.Where(d => d.Id == formData.Film.DirectorId).FirstOrDefault();

            //db.Pizzas.Add(formData.Pizza);
            //db.SaveChanges();
            contentRepository.CreateFilm(formData.Film, formData.SelectedCategories, formData.SelectedActors, director);

            return RedirectToAction("Index");
        }
    }
}
