using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Portfolio.Api.Models.Entities
{
    [Table("skills")]
    public class Skills
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }

        [Column("portfolio_id")]
        public long PortfolioId { get; set; }

        [Column("skill_name")]
        public string SkillName { get; set; } = string.Empty;

        [Column("short_form")]
        public string? ShortForm { get; set; }

        [Column("category")]
        public string? Category { get; set; }

        [Column("logo_url")]
        public string? LogoUrl { get; set; }

        [Column("icon_name")]
        public string? IconName { get; set; }

        [Column("brand_color")]
        public string? BrandColor { get; set; }

        [Column("secondary_color")]
        public string? SecondaryColor { get; set; }

        [Column("proficiency_level")]
        public string? ProficiencyLevel { get; set; }

        [Column("years_of_experience")]
        public decimal? YearsOfExperience { get; set; }

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