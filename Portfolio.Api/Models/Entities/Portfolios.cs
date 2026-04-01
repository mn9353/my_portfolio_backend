using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Portfolio.Api.Models.Entities
{
    [Table("portfolio")]
    public class Portfolios
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }

        [Column("full_name")]
        public string FullName { get; set; } = string.Empty;

        [Column("short_form")]
        public string? ShortForm { get; set; }

        [Column("open_to_work")]
        public bool OpenToWork { get; set; }

        [Column("open_to_work_text")]
        public string? OpenToWorkDescription { get; set; }

        [Column("role")]
        public string? Role { get; set; }

        [Column("headline")]
        public string? Headline { get; set; }

        [Column("subheadline")]
        public string? Subheadline { get; set; }

        [Column("about_me")]
        public string? AboutMe { get; set; }

        [Column("email")]
        public string? Email { get; set; }

        [Column("phone_number")]
        public string? PhoneNumber { get; set; }

        [Column("location")]
        public string? Location { get; set; }

        [Column("linkedin_url")]
        public string? LinkedinUrl { get; set; }

        [Column("github_url")]
        public string? GithubUrl { get; set; }

        [Column("resume_url")]
        public string? ResumeUrl { get; set; }

        [Column("profile_image_url")]
        public string? ProfileImageUrl { get; set; }

        [Column("theme_name")]
        public string? ThemeName { get; set; }

        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; }
    }
}