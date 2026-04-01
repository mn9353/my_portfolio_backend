using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Portfolio.Api.Models.Entities
{
    [Table("language_list")]
    public class LanguageList
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }

        [Column("language_code")]
        public string LanguageCode { get; set; } = string.Empty;

        [Column("language")]
        public string Language { get; set; } = string.Empty;

        [Column("is_active")]
        public bool IsActive { get; set; } = true;
    }
}
