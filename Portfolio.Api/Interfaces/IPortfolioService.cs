using Portfolio.Api.Models.DTOs;
using Portfolio.Api.Models.Entities;

namespace Portfolio.Api.Interfaces
{
    public interface IPortfolioService
    {
        Task<PortfolioBasicDto?> GetPortfolioBasicAsync(long portfolioId);
        Task<List<Projects>> GetProjectsAsync(long portfolioId);
        Task<List<Experiences>> GetExperiencesAsync(long portfolioId);
        Task<List<Education>> GetEducationAsync(long portfolioId);
        Task<List<Skills>> GetSkillsAsync(long portfolioId);
        Task<List<Certifications>> GetCertificationsAsync(long portfolioId);
        Task<List<Achievements>> GetAchievementsAsync(long portfolioId);
        Task<List<SocialLinks>> GetSocialLinksAsync(long portfolioId);
        Task<List<Testimonials>> GetTestimonialsAsync(long portfolioId);
    }
}
