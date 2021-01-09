using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace TorchFireFilms.Api.Films.Data.Models
{
    [Table("film_i18n")]
    public class FilmI18n
    {
        [Column("film_i18n_id")]
        public int FilmI18nId { get; set; }
        [Column("film_id")]
        public int FilmId { get; set; }
        [Column("iso_language_639_id")]
        public int IsoLanguage639Id { get; set; }
        [Column("title")]
        public string Title { get; set; }
        [Column("description")]
        public string Description { get; set; }
        [Column("created_date")]
        public DateTime CreatedDate { get; set; }
        [Column("created_user_id")]
        public int CreatedUserId { get; set; }
        [Column("modified_date")]
        public DateTime ModifiedDate { get; set; }
        [Column("modified_user_id")]
        public int ModifiedUserId { get; set; }
    }
}
