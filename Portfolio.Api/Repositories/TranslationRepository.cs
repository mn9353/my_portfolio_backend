using Microsoft.EntityFrameworkCore;
using Portfolio.Api.Data;
using Portfolio.Api.Interfaces;
using Portfolio.Api.Models.DTOs;
using Portfolio.Api.Models.Entities;

namespace Portfolio.Api.Repositories
{
    public class TranslationRepository : ITranslationRepository
    {
        private readonly AppDbContext _context;

        public TranslationRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<TranslationBulkUpsertResponseDto> UpsertTranslationsAsync(
            IReadOnlyCollection<TranslationBulkUpsertItemDto> items,
            CancellationToken cancellationToken = default)
        {
            var languageCodes = items.Select(x => x.LanguageCode).Distinct().ToList();
            var keys = items.Select(x => x.TranslationKey).Distinct().ToList();

            var existing = await _context.TranslationTable
                .Where(x => languageCodes.Contains(x.LanguageCode) && keys.Contains(x.TranslationKey))
                .ToListAsync(cancellationToken);

            var existingMap = existing.ToDictionary(
                x => (LanguageCode: x.LanguageCode, Key: x.TranslationKey),
                x => x);

            var now = DateTime.UtcNow;
            var insertedCount = 0;
            var updatedCount = 0;

            foreach (var item in items)
            {
                var mapKey = (item.LanguageCode, item.TranslationKey);
                if (existingMap.TryGetValue(mapKey, out var entity))
                {
                    entity.TranslatedValue = item.TranslationValue;
                    entity.UpdatedAt = now;
                    updatedCount++;
                    continue;
                }

                _context.TranslationTable.Add(new Translations
                {
                    TranslationKey = item.TranslationKey,
                    TranslatedValue = item.TranslationValue,
                    LanguageCode = item.LanguageCode,
                    UpdatedAt = now
                });

                insertedCount++;
            }

            if (insertedCount > 0 || updatedCount > 0)
            {
                await _context.SaveChangesAsync(cancellationToken);
            }

            return new TranslationBulkUpsertResponseDto
            {
                TotalReceived = items.Count,
                InsertedCount = insertedCount,
                UpdatedCount = updatedCount,
                AffectedLanguageCodes = languageCodes
            };
        }

        public async Task<List<TranslationKeyValueDto>> GetTranslationsByLanguageCodeAsync(
            string languageCode,
            CancellationToken cancellationToken = default)
        {
            return await _context.TranslationTable
                .AsNoTracking()
                .Where(x => x.LanguageCode == languageCode)
                .OrderBy(x => x.TranslationKey)
                .Select(x => new TranslationKeyValueDto
                {
                    TranslationKey = x.TranslationKey,
                    TranslationValue = x.TranslatedValue
                })
                .ToListAsync(cancellationToken);
        }
    }
}
