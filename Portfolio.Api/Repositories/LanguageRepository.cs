using Microsoft.EntityFrameworkCore;
using Portfolio.Api.Data;
using Portfolio.Api.Interfaces;
using Portfolio.Api.Models.DTOs;

namespace Portfolio.Api.Repositories
{
    public class LanguageRepository : ILanguageRepository
    {
        private readonly AppDbContext _context;

        public LanguageRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<LanguageDto>> GetLanguagesAsync(bool includeInactive, CancellationToken cancellationToken = default)
        {
            var query = _context.LanguageListTable.AsNoTracking().AsQueryable();

            if (!includeInactive)
            {
                query = query.Where(x => x.IsActive);
            }

            return await query
                .OrderBy(x => x.Language)
                .Select(x => new LanguageDto
                {
                    LanguageCode = x.LanguageCode,
                    Language = x.Language,
                    IsActive = x.IsActive
                })
                .ToListAsync(cancellationToken);
        }
    }
}
