namespace Portfolio.Api.Models.DTOs
{
    public class SectionDto
    {
        public string SectionKey { get; set; } = string.Empty;

        public string? Title { get; set; }

        public string? Subtitle { get; set; }

        public string? Description { get; set; }

        public string? ButtonText { get; set; }

        public string? ButtonUrl { get; set; }

        public string? SectionType { get; set; }

        public int DisplayOrder { get; set; }

        public bool IsVisible { get; set; }

        public string? BackgroundStyle { get; set; }
    }
}