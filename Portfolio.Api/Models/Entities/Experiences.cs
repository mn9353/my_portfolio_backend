using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Portfolio.Api.Models.Entities
{
    [Table("experience")]
    public class Experiences
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }

        [Column("portfolio_id")]
        public long PortfolioId { get; set; }

        [Column("company_name")]
        public string CompanyName { get; set; } = string.Empty;

        [Column("role")]
        public string Role { get; set; } = string.Empty;

        [Column("short_description")]
        public string? ShortDescription { get; set; }

        [Column("detailed_description")]
        public List<string>? DetailedDescription { get; set; }

        [Column("technologies_used")]
        public List<TechnologyItem>? TechnologiesUsed { get; set; }

        [Column("location")]
        public string? Location { get; set; }

        [Column("employment_type")]
        public string? EmploymentType { get; set; }

        [Column("start_date")]
        public DateTime? StartDate { get; set; }

        [Column("end_date")]
        public DateTime? EndDate { get; set; }

        [Column("is_current")]
        public bool IsCurrent { get; set; }

        [Column("display_order")]
        public int DisplayOrder { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; }

        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; }
    }
}
