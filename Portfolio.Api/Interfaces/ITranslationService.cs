using Portfolio.Api.Models.DTOs;

namespace Portfolio.Api.Interfaces
{
    public interface ITranslationService
    {
        Task<TranslationBulkUpsertResponseDto> UpsertTranslationsAsync(
            IReadOnlyCollection<TranslationBulkUpsertItemDto> items,
            CancellationToken cancellationToken = default);

        Task<IReadOnlyList<TranslationKeyValueDto>> GetTranslationsByLanguageCodeAsync(
            string languageCode,
            CancellationToken cancellationToken = default);
    }
}
