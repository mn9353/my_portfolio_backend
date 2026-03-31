using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Portfolio.Api.Models.Entities
{
    [Table("translations")]
    public class Translations
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }

        [Column("translation_key")]
        public string TranslationKey { get; set; } = string.Empty;

        [Column("translated_value")]
        public string TranslatedValue { get; set; } = string.Empty;

        [Column("language_code")]
        public string LanguageCode { get; set; } = string.Empty;

        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; }
    }
}