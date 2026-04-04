using Microsoft.EntityFrameworkCore;
using Portfolio.Api.Data;
using Portfolio.Api.Interfaces;
using Portfolio.Api.Models.DTOs;

namespace Portfolio.Api.Repositories
{
    public class SectionRepository : ISectionRepository
    {
        private readonly AppDbContext _context;

        public SectionRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<SectionDto>> GetSectionsByPortfolioIdAsync(long portfolioId)
        {
            return await _context.SectionsTable
                .Where(s => s.PortfolioId == portfolioId && s.IsVisible == true)
                .OrderBy(s => s.DisplayOrder ?? int.MaxValue)
                .Select(s => new SectionDto
                {
                    SectionKey = s.SectionKey ?? string.Empty,
                    Title = s.Title,
                    Subtitle = s.Subtitle,
                    Description = s.Description,
                    ButtonText = s.ButtonText,
                    ButtonUrl = s.ButtonUrl,
                    SectionType = s.SectionType,
                    DisplayOrder = s.DisplayOrder ?? 0,
                    IsVisible = s.IsVisible ?? false,
                    BackgroundStyle = s.BackgroundStyle
                })
                .ToListAsync();
        }
    }
}
