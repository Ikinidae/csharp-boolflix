namespace csharp_boolflix.Models
{
    public class Film : Content
    {
        public int Duration { get; set; }
        public int? RemainingTime { get; set; }
    }
}
