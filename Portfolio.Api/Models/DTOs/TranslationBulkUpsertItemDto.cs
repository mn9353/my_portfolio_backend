using System.ComponentModel.DataAnnotations;

namespace Portfolio.Api.Models.DTOs
{
    public class TranslationBulkUpsertItemDto
    {
        [Required]
        public string TranslationKey { get; set; } = string.Empty;

        [Required]
        public string TranslationValue { get; set; } = string.Empty;

        [Required]
        public string LanguageCode { get; set; } = string.Empty;
    }
}
