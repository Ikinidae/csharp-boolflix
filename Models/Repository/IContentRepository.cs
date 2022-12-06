namespace csharp_boolflix.Models.Repository
{
    public interface IContentRepository
    {
        List<Film> AllFilms();
        void CreateFilm(Film film, List<int> selectedActors, List<int> selectedCategories, Director director);
        Film GetFilmById(int id);
    }
}