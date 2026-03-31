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
    }
}
