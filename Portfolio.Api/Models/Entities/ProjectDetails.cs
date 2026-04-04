using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Portfolio.Api.Models.Entities
{
    [Table("project_details")]
    public class ProjectDetails
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }

        [Column("project_id")]
        public long ProjectId { get; set; }

        [Column("role")]
        public string? Role { get; set; }

        [Column("team_size")]
        public int? TeamSize { get; set; }

        [Column("duration_start")]
        public DateTime? DurationStart { get; set; }

        [Column("duration_end")]
        public DateTime? DurationEnd { get; set; }

        [Column("is_current")]
        public bool IsCurrent { get; set; }

        [Column("architecture")]
        public string? Architecture { get; set; }

        [Column("problem_statement")]
        public string? ProblemStatement { get; set; }

        [Column("solution_approach")]
        public string? SolutionApproach { get; set; }

        [Column("outcome_summary")]
        public string? OutcomeSummary { get; set; }

        [Column("created_at")]
        public DateTime? CreatedAt { get; set; }

        [Column("updated_at")]
        public DateTime? UpdatedAt { get; set; }
    }
}
