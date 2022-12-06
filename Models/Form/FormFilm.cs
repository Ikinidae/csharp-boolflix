using Microsoft.AspNetCore.Mvc.Rendering;

namespace csharp_boolflix.Models.Form
{
    public class FormFilm
    {
        public Film Film { get; set; }
        public List<SelectListItem>? Categories { get; set; }
        public List<int>? SelectedCategories { get; set; }
        public List<SelectListItem>? Actors { get; set; }
        public List<int>? SelectedActors { get; set; }
        public List<Director>? Directors { get; set; }
    }
}
