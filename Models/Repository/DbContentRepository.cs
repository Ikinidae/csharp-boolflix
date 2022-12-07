using csharp_boolflix.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace csharp_boolflix.Models.Repository
{
    public class DbContentRepository : IContentRepository
    {
        private BoolflixDbContext db;
        public DbContentRepository(BoolflixDbContext _db) : base()
        {
            db = _db;
        }

        //Film
        public List<Film> AllFilms()
        {
            return db.Films.Include(film => film.Actors).Include(film => film.Categories).Include(film => film.Director).ToList();
        }
        public Film GetFilmById(int id)
        {
            return db.Films.Where(f => f.Id == id).Include("Actors").Include("Categories").Include("Director").FirstOrDefault();
        }

        public void CreateFilm(Film film, List<int> selectedActors, List<int> selectedCategories)
        {

            film.Actors = new List<Actor>();

            foreach (int actorId in selectedActors)
            {
                Actor actor = db.Actors.Where(a => a.Id == actorId).FirstOrDefault();
                film.Actors.Add(actor);
            }

            film.Categories = new List<Category>();

            foreach (int categoryId in selectedCategories)
            {
                Category category = db.Categories.Where(c => c.Id == categoryId).FirstOrDefault();
                film.Categories.Add(category);
            }

            db.Films.Add(film);
            db.SaveChanges();
        }

        public void DeleteFilm(Film film)
        {
            db.Films.Remove(film);
            db.SaveChanges();
        }


        //Serie
        public List<Serie> AllSeries()
        {
            return db.Series.Include(serie => serie.Actors).Include(serie => serie.Categories).Include(serie => serie.Director).Include(serie => serie.Seasons).ToList();
        }

        public Serie GetSerieById(int id)
        {
            return db.Series.Where(s => s.Id == id).Include("Actors").Include("Categories").Include("Director").Include("Seasons").Include("Seasons.Episodes").FirstOrDefault();
        }

        public void CreateSerie(Serie serie, List<int> selectedActors, List<int> selectedCategory)
        {

            serie.Actors = new List<Actor>();

            foreach (int actorId in selectedActors)
            {
                Actor actor = db.Actors.Where(a => a.Id == actorId).FirstOrDefault();
                serie.Actors.Add(actor);
            }

            serie.Categories = new List<Category>();

            foreach (int categoryId in selectedCategory)
            {
                Category category = db.Categories.Where(g => g.Id == categoryId).FirstOrDefault();
                serie.Categories.Add(category);
            }

            db.Series.Add(serie);
            db.SaveChanges();
        }

        public void DeleteSerie(Serie serie)
        {
            db.Series.Remove(serie);
            db.SaveChanges();
        }

        //stagione
        public void CreateSeason (Season season)
        {
            db.Seasons.Add(season);
            db.SaveChanges();
        }

        //episodes
        public void CreateEpisode(Episode episode)
        {
            db.Episodes.Add(episode);
            db.SaveChanges();
        }

        public List<Episode> GetEpisodes(int id)
        {
            return db.Episodes.Where(e => e.SeasonId == id).ToList();
        }
    }
}
