using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Portfolio.Api.Models.Entities
{
    [Table("social_links")]
    public class SocialLinks
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }

        [Column("portfolio_id")]
        public long PortfolioId { get; set; }

        [Column("platform_name")]
        public string PlatformName { get; set; } = string.Empty;

        [Column("display_name")]
        public string? DisplayName { get; set; }

        [Column("profile_url")]
        public string ProfileUrl { get; set; } = string.Empty;

        [Column("icon_name")]
        public string? IconName { get; set; }

        [Column("brand_color")]
        public string? BrandColor { get; set; }

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