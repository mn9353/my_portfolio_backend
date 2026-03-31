using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Portfolio.Api.Models.Entities
{
    [Table("education")]
    public class Education
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }

        [Column("portfolio_id")]
        public long PortfolioId { get; set; }

        [Column("institution_name")]
        public string InstitutionName { get; set; } = string.Empty;

        [Column("degree")]
        public string Degree { get; set; } = string.Empty;

        [Column("field_of_study")]
        public string? FieldOfStudy { get; set; }

        [Column("location")]
        public string? Location { get; set; }

        [Column("grade")]
        public string? Grade { get; set; }

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