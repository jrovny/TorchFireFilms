using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace TorchFireFilms.Api.Films.Data.Models
{
    [Table("film")]
    public class Film
    {
        [Column("film_id")]
        public int FilmId { get; set; }
        [Column("runtime_minutes")]
        public int RuntimeMinutes { get; set; }
        [Column("released_date")]
        public DateTime ReleasedDate { get; set; }
        [Column("url")]
        public Uri Uri { get; set; }
        [Column("image")]
        public Uri Image { get; set; }
        [Column("thumbnail")]
        public Uri Thumbnail { get; set; }
        [Column("slug")]
        public string Slug { get; set; }
        [Column("created_date")]
        public DateTime CreatedDate { get; set; }
        [Column("created_user_id")]
        public int CreatedUserId { get; set; }
        [Column("modified_date")]
        public DateTime ModifiedDate { get; set; }
        [Column("modified_user_id")]
        public int ModifiedUserId { get; set; }
        [Column("deleted")]
        public bool Deleted { get; set; }
        public FilmI18n FilmTranslation { get; set; }
    }
}
