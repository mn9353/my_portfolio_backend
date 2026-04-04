namespace Portfolio.Api.Models.DTOs
{
    public class PortfolioBasicDto
    {
        public long Id { get; set; }

        public string FullName { get; set; } = string.Empty;

        public string? ShortForm { get; set; }

        public string? Role { get; set; }
        public float? TotalExperience { get; set; }
        public string? CurrentCompany { get; set; }
        public bool OpenToWork { get; set; }
        public string? OpenToWorkDescription { get; set; }

        public string? Headline { get; set; }

        public string? Subheadline { get; set; }

        public string? AboutMe { get; set; }

        public string? Email { get; set; }

        public string? PhoneNumber { get; set; }

        public string? Location { get; set; }

        public string? LinkedinUrl { get; set; }

        public string? GithubUrl { get; set; }

        public string? ResumeUrl { get; set; }

        public string? ProfileImageUrl { get; set; }

        public string? ThemeName { get; set; }
    }
}
