using Portfolio.Api.Models.DTOs;

namespace Portfolio.Api.Interfaces
{
	public interface ISectionService
	{
		Task<List<SectionDto>> GetSectionsByPortfolioIdAsync(long portfolioId);
	}
}