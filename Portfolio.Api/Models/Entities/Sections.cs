using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Portfolio.Api.Models.Entities
{
    [Table("sections")]
    public class Sections
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }

        [Column("portfolio_id")]
        public long PortfolioId { get; set; }

        [Column("section_key")]
        public string? SectionKey { get; set; }

        [Column("title")]
        public string? Title { get; set; }

        [Column("subtitle")]
        public string? Subtitle { get; set; }

        [Column("description")]
        public string? Description { get; set; }

        [Column("button_text")]
        public string? ButtonText { get; set; }

        [Column("button_url")]
        public string? ButtonUrl { get; set; }

        [Column("section_type")]
        public string? SectionType { get; set; }

        [Column("display_order")]
        public int? DisplayOrder { get; set; }

        [Column("is_visible")]
        public bool? IsVisible { get; set; }

        [Column("background_style")]
        public string? BackgroundStyle { get; set; }

        [Column("created_at")]
        public DateTime? CreatedAt { get; set; }

        [Column("updated_at")]
        public DateTime? UpdatedAt { get; set; }
    }
}
