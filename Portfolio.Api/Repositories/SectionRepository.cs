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
                .Where(s => s.PortfolioId == portfolioId && s.IsVisible)
                .OrderBy(s => s.DisplayOrder)
                .Select(s => new SectionDto
                {
                    SectionKey = s.SectionKey,
                    Title = s.Title,
                    Subtitle = s.Subtitle,
                    Description = s.Description,
                    ButtonText = s.ButtonText,
                    ButtonUrl = s.ButtonUrl,
                    SectionType = s.SectionType,
                    DisplayOrder = s.DisplayOrder,
                    IsVisible = s.IsVisible,
                    BackgroundStyle = s.BackgroundStyle
                })
                .ToListAsync();
        }
    }
}