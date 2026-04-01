using Portfolio.Api.Models.DTOs;

namespace Portfolio.Api.Interfaces
{
    public interface ITranslationRepository
    {
        Task<TranslationBulkUpsertResponseDto> UpsertTranslationsAsync(
            IReadOnlyCollection<TranslationBulkUpsertItemDto> items,
            CancellationToken cancellationToken = default);

        Task<List<TranslationKeyValueDto>> GetTranslationsByLanguageCodeAsync(
            string languageCode,
            CancellationToken cancellationToken = default);
    }
}
