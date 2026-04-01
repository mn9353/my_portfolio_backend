namespace Portfolio.Api.Models.DTOs
{
    public class LanguageDto
    {
        public string LanguageCode { get; set; } = string.Empty;
        public string Language { get; set; } = string.Empty;
        public bool IsActive { get; set; }
    }
}
