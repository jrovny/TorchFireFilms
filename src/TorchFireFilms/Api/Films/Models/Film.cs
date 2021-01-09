using System;

namespace TorchFireFilms.Api.Films.Models
{
    public class Film
    {
        public int FilmId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int RuntimeMinutes { get; set; }
        public DateTime ReleasedDate { get; set; }
        public Uri Uri { get; set; }
        public Uri Image { get; set; }
        public Uri Thumbnail { get; set; }
    }
}
