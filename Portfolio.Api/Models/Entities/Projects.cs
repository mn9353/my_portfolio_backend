using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Portfolio.Api.Models.Entities
{
    [Table("projects")]
    public class Projects
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }

        [Column("portfolio_id")]
        public long PortfolioId { get; set; }

        [Column("project_key")]
        public string ProjectKey { get; set; } = string.Empty;

        [Column("title")]
        public string Title { get; set; } = string.Empty;

        [Column("short_description")]
        public string? ShortDescription { get; set; }

        [Column("detailed_description")]
        public string? DetailedDescription { get; set; }

        [Column("technologies_used")]
        public List<TechnologyItem>? TechnologiesUsed { get; set; }

        [Column("github_url")]
        public string? GithubUrl { get; set; }

        [Column("live_url")]
        public string? LiveUrl { get; set; }

        [Column("image_url")]
        public string? ImageUrl { get; set; }

        [Column("project_type")]
        public string? ProjectType { get; set; }

        [Column("status")]
        public string? Status { get; set; }

        [Column("is_featured")]
        public bool IsFeatured { get; set; }

        [Column("display_order")]
        public int DisplayOrder { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; }

        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; }
    }


    public class TechnologyItem
    {
        public string Technology { get; set; } = string.Empty;
        public string? Color { get; set; }
        public string? LogoUrl { get; set; }
    }
}

