namespace Portfolio.Api.Models.DTOs
{
    public class ProjectFullDetailsDto
    {
        public ProjectSummaryDto Project { get; set; } = new();
        public ProjectMainDetailsDto Details { get; set; } = new();
        public ProjectPointsDto Points { get; set; } = new();
        public List<ProjectMediaDto> Media { get; set; } = new();
        public List<ProjectLinkDto> Links { get; set; } = new();
    }

    public class ProjectSummaryDto
    {
        public long Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? ShortDescription { get; set; }
        public List<string> TechnologiesUsed { get; set; } = new();
        public string? GithubUrl { get; set; }
        public string? LiveUrl { get; set; }
        public string? Status { get; set; }
    }

    public class ProjectMainDetailsDto
    {
        public string? Role { get; set; }
        public int? TeamSize { get; set; }
        public DateTime? DurationStart { get; set; }
        public DateTime? DurationEnd { get; set; }
        public bool IsCurrent { get; set; }
        public string? Architecture { get; set; }
        public string? ProblemStatement { get; set; }
        public string? SolutionApproach { get; set; }
        public string? OutcomeSummary { get; set; }
    }

    public class ProjectPointsDto
    {
        public List<string> Features { get; set; } = new();
        public List<string> Impact { get; set; } = new();
        public List<string> Responsibilities { get; set; } = new();
    }

    public class ProjectMediaDto
    {
        public string Type { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
        public string? Caption { get; set; }
        public int DisplayOrder { get; set; }
    }

    public class ProjectLinkDto
    {
        public string Label { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
    }
}
