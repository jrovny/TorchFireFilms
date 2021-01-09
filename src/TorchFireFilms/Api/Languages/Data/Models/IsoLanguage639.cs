using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace TorchFireFilms.Api.Languages.Data.Models
{
    [Table("iso_language_639")]
    public class IsoLanguage639
    {
        [Column("iso_language_639_id")]
        public int IsoLanguage639Id { get; set; }
        [Column("iso_code_639_1")]
        public string IsoCode6391 { get; set; }
        [Column("iso_code_639_2")]
        public string IsoCode6392 { get; set; }
        [Column("is_default")]
        public bool IsDefault { get; set; }
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
