using System;
using System.ComponentModel.DataAnnotations;

namespace TorchFireFilms.Api.Films.Models
{
    public class FilmSave
    {
        public int FilmId { get; set; }
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        public int RuntimeMinutes { get; set; }
        public DateTime ReleasedDate { get; set; }
        public Uri Uri { get; set; }
        public Uri Image { get; set; }
        public Uri Thumbnail { get; set; }
        public string Slug { get; set; }
        [Range(1, int.MaxValue)]
        public int IsoLanguage639Id { get; set; }
    }
}