using Portfolio.Api.Models.DTOs;

namespace Portfolio.Api.Interfaces
{
    public interface ISectionRepository
    {
        Task<List<SectionDto>> GetSectionsByPortfolioIdAsync(long portfolioId);
    }
}