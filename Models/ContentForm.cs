using Microsoft.AspNetCore.Mvc.Rendering;

namespace csharp_boolflix.Models
{
    public class ContentForm
    {
        public Film Film { get; set; }
        public Serie Serie { get; set; }
        public Season Season { get; set; }
        public Episode Episode { get; set; }
        public List<SelectListItem>? Categories { get; set; }
        public List<int>? SelectedCategories { get; set; }
        public List<SelectListItem>? Actors { get; set; }
        public List<int>? SelectedActors { get; set; }
        public List<Director>? Directors { get; set; }
    }
}
