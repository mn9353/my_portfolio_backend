using Portfolio.Api.Interfaces;
using Portfolio.Api.Models.DTOs;
using Portfolio.Api.Models.Entities;

namespace Portfolio.Api.Services
{
    public class PortfolioService : IPortfolioService
    {
        private readonly IPortfolioRepository _portfolioRepository;

        public PortfolioService(IPortfolioRepository portfolioRepository)
        {
            _portfolioRepository = portfolioRepository;
        }

        public async Task<PortfolioBasicDto?> GetPortfolioBasicAsync(long portfolioId)
        {
            return await _portfolioRepository.GetPortfolioBasicAsync(portfolioId);
        }

        public async Task<List<Projects>> GetProjectsAsync(long portfolioId) =>
            await _portfolioRepository.GetProjectsAsync(portfolioId);

        public async Task<ProjectFullDetailsDto?> GetProjectDetailsByProjectIdAsync(long projectId) =>
            await _portfolioRepository.GetProjectDetailsByProjectIdAsync(projectId);

        public async Task<List<Experiences>> GetExperiencesAsync(long portfolioId) =>
            await _portfolioRepository.GetExperiencesAsync(portfolioId);

        public async Task<List<Education>> GetEducationAsync(long portfolioId) =>
            await _portfolioRepository.GetEducationAsync(portfolioId);

        public async Task<List<Skills>> GetSkillsAsync(long portfolioId) =>
            await _portfolioRepository.GetSkillsAsync(portfolioId);

        public async Task<List<Certifications>> GetCertificationsAsync(long portfolioId) =>
            await _portfolioRepository.GetCertificationsAsync(portfolioId);

        public async Task<List<Achievements>> GetAchievementsAsync(long portfolioId) =>
            await _portfolioRepository.GetAchievementsAsync(portfolioId);

        public async Task<List<SocialLinks>> GetSocialLinksAsync(long portfolioId) =>
            await _portfolioRepository.GetSocialLinksAsync(portfolioId);

        public async Task<List<Testimonials>> GetTestimonialsAsync(long portfolioId) =>
            await _portfolioRepository.GetTestimonialsAsync(portfolioId);
    }
}
