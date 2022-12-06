namespace csharp_boolflix.Models.Repository
{
    public interface IContentRepository
    {
        //film
        List<Film> AllFilms();
        void CreateFilm(Film film, List<int> selectedActors, List<int> selectedCategories);
        void DeleteFilm(Film film);
        Film GetFilmById(int id);
        
        //serie
        List<Serie> AllSeries();
        void CreateSerie(Serie serie, List<int> selectedActors, List<int> selectedCategories);
        Serie GetSerieById(int id);
        void DeleteSerie(Serie serie);
        void CreateSeason(Season season);
    }
}