namespace csharp_boolflix.Models
{
    public class Serie : Content
    {
        public int EpisodesNumber { get; set; }
        public List<Season> Seasons { get; set; }
    }
}
