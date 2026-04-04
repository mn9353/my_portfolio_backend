using Microsoft.EntityFrameworkCore;
using Portfolio.Api.Data;
using Portfolio.Api.Interfaces;
using Portfolio.Api.Models.DTOs;
using Portfolio.Api.Models.Entities;

namespace Portfolio.Api.Repositories
{
    public class PortfolioRepository : IPortfolioRepository
    {
        private readonly AppDbContext _context;

        public PortfolioRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<PortfolioBasicDto?> GetPortfolioBasicAsync(long portfolioId)
        {
            return await _context.PortfoliosTable
                .Where(p => p.Id == portfolioId)
                .Select(p => new PortfolioBasicDto
                {
                    Id = p.Id,
                    FullName = p.FullName,
                    ShortForm = p.ShortForm,
                    Role = p.Role,
                    TotalExperience = p.TotalExperience,
                    CurrentCompany = p.CurrentCompany,
                    OpenToWork = p.OpenToWork,
                    OpenToWorkDescription = p.OpenToWorkDescription,
                    Headline = p.Headline,
                    Subheadline = p.Subheadline,
                    AboutMe = p.AboutMe,
                    Email = p.Email,
                    PhoneNumber = p.PhoneNumber,
                    Location = p.Location,
                    LinkedinUrl = p.LinkedinUrl,
                    GithubUrl = p.GithubUrl,
                    ResumeUrl = p.ResumeUrl,
                    ProfileImageUrl = p.ProfileImageUrl,
                    ThemeName = p.ThemeName
                })
                .FirstOrDefaultAsync();
        }

        public async Task<List<Projects>> GetProjectsAsync(long portfolioId) =>
            await _context.ProjectTable
                .AsNoTracking()
                .Where(x => x.PortfolioId == portfolioId)
                .OrderBy(x => x.DisplayOrder)
                .ToListAsync();

        public async Task<ProjectFullDetailsDto?> GetProjectDetailsByProjectIdAsync(long projectId)
        {
            var project = await _context.ProjectTable
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == projectId);

            if (project == null)
                return null;

            var details = await _context.ProjectDetailsTable
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.ProjectId == projectId);

            var points = await _context.ProjectDetailPointsTable
                .AsNoTracking()
                .Where(x => x.ProjectId == projectId)
                .OrderBy(x => x.DisplayOrder)
                .ToListAsync();

            var media = await _context.ProjectMediaTable
                .AsNoTracking()
                .Where(x => x.ProjectId == projectId)
                .OrderBy(x => x.DisplayOrder)
                .ToListAsync();

            var links = await _context.ProjectLinksTable
                .AsNoTracking()
                .Where(x => x.ProjectId == projectId)
                .OrderBy(x => x.DisplayOrder)
                .ToListAsync();

            return new ProjectFullDetailsDto
            {
                Project = new ProjectSummaryDto
                {
                    Id = project.Id,
                    Title = project.Title,
                    ShortDescription = project.ShortDescription,
                    TechnologiesUsed = project.TechnologiesUsed?
                        .Select(x => x.Technology)
                        .Where(x => !string.IsNullOrWhiteSpace(x))
                        .ToList() ?? new List<string>(),
                    GithubUrl = project.GithubUrl,
                    LiveUrl = project.LiveUrl,
                    Status = project.Status
                },
                Details = new ProjectMainDetailsDto
                {
                    Role = details?.Role,
                    TeamSize = details?.TeamSize,
                    DurationStart = details?.DurationStart,
                    DurationEnd = details?.DurationEnd,
                    IsCurrent = details?.IsCurrent ?? false,
                    Architecture = details?.Architecture,
                    ProblemStatement = details?.ProblemStatement,
                    SolutionApproach = details?.SolutionApproach,
                    OutcomeSummary = details?.OutcomeSummary
                },
                Points = new ProjectPointsDto
                {
                    Features = MapPoints(points, "feature", "features"),
                    Impact = MapPoints(points, "impact"),
                    Responsibilities = MapPoints(points, "responsibility", "responsibilities")
                },
                Media = media.Select(x => new ProjectMediaDto
                {
                    Type = x.MediaType,
                    Url = x.MediaUrl,
                    Caption = x.Caption,
                    DisplayOrder = x.DisplayOrder
                }).ToList(),
                Links = links.Select(x => new ProjectLinkDto
                {
                    Label = x.Label,
                    Url = x.Url
                }).ToList()
            };
        }

        public async Task<List<Experiences>> GetExperiencesAsync(long portfolioId) =>
            await _context.ExperiencesTable
                .AsNoTracking()
                .Where(x => x.PortfolioId == portfolioId)
                .OrderBy(x => x.DisplayOrder)
                .ToListAsync();

        public async Task<List<Education>> GetEducationAsync(long portfolioId) =>
            await _context.EducationTable
                .AsNoTracking()
                .Where(x => x.PortfolioId == portfolioId)
                .OrderBy(x => x.DisplayOrder)
                .ToListAsync();

        public async Task<List<Skills>> GetSkillsAsync(long portfolioId) =>
            await _context.SkillsTable
                .AsNoTracking()
                .Where(x => x.PortfolioId == portfolioId)
                .OrderBy(x => x.DisplayOrder)
                .ToListAsync();

        public async Task<List<Certifications>> GetCertificationsAsync(long portfolioId) =>
            await _context.CertificationsTable
                .AsNoTracking()
                .Where(x => x.PortfolioId == portfolioId)
                .OrderBy(x => x.DisplayOrder)
                .ToListAsync();

        public async Task<List<Achievements>> GetAchievementsAsync(long portfolioId) =>
            await _context.AchievementsTable
                .AsNoTracking()
                .Where(x => x.PortfolioId == portfolioId)
                .OrderBy(x => x.DisplayOrder)
                .ToListAsync();

        public async Task<List<SocialLinks>> GetSocialLinksAsync(long portfolioId) =>
            await _context.SocialLinksTable
                .AsNoTracking()
                .Where(x => x.PortfolioId == portfolioId)
                .OrderBy(x => x.DisplayOrder)
                .ToListAsync();

        public async Task<List<Testimonials>> GetTestimonialsAsync(long portfolioId) =>
            await _context.TestimonialsTable
                .AsNoTracking()
                .Where(x => x.PortfolioId == portfolioId)
                .OrderBy(x => x.DisplayOrder)
                .ToListAsync();

        private static List<string> MapPoints(IEnumerable<ProjectDetailPoints> points, params string[] pointTypes)
        {
            var allowedTypes = new HashSet<string>(pointTypes, StringComparer.OrdinalIgnoreCase);

            return points
                .Where(x => allowedTypes.Contains(x.PointType) && !string.IsNullOrWhiteSpace(x.Content))
                .OrderBy(x => x.DisplayOrder)
                .Select(x => x.Content)
                .ToList();
        }
    }
}
