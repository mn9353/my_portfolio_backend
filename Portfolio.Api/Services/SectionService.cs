using Portfolio.Api.Interfaces;
using Portfolio.Api.Models.DTOs;

namespace Portfolio.Api.Services
{
    public class SectionService : ISectionService
    {
        private readonly ISectionRepository _sectionRepository;

        public SectionService(ISectionRepository sectionRepository)
        {
            _sectionRepository = sectionRepository;
        }

        public async Task<List<SectionDto>> GetSectionsByPortfolioIdAsync(long portfolioId)
        {
            return await _sectionRepository.GetSectionsByPortfolioIdAsync(portfolioId);
        }
    }
}