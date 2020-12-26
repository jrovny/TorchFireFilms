using System.ComponentModel.DataAnnotations.Schema;

namespace TorchFireFilms.Api.Values
{
    [Table("value")]
    public class Value
    {
        [Column("value_id")]
        public int ValueId { get; set; }
        [Column("name")]
        public string Name { get; set; }
        [Column("description")]
        public string Description { get; set; }
    }
}
