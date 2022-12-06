using Microsoft.AspNetCore.Mvc;

namespace csharp_boolflix.Controllers
{
    public class SerieController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
