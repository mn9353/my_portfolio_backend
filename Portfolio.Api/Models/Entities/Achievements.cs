using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Portfolio.Api.Models.Entities
{
    [Table("achievements")]
    public class Achievements
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }

        [Column("portfolio_id")]
        public long PortfolioId { get; set; }

        [Column("title")]
        public string Title { get; set; } = string.Empty;

        [Column("metric_value")]
        public string? MetricValue { get; set; }

        [Column("metric_label")]
        public string? MetricLabel { get; set; }

        [Column("description")]
        public string? Description { get; set; }

        [Column("icon_name")]
        public string? IconName { get; set; }

        [Column("highlight_color")]
        public string? HighlightColor { get; set; }

        [Column("is_visible")]
        public bool IsVisible { get; set; }

        [Column("display_order")]
        public int DisplayOrder { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; }

        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; }
    }
}