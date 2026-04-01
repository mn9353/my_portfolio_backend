using Microsoft.Extensions.Caching.Memory;
using Portfolio.Api.Interfaces;
using Portfolio.Api.Models.DTOs;

namespace Portfolio.Api.Services
{
    public class TranslationService : ITranslationService
    {
        private readonly ITranslationRepository _translationRepository;
        private readonly IMemoryCache _memoryCache;

        private static readonly TimeSpan CacheAbsoluteExpiration = TimeSpan.FromMinutes(30);
        private static readonly TimeSpan CacheSlidingExpiration = TimeSpan.FromMinutes(10);
        private const string CacheKeyPrefix = "translations:language:";

        public TranslationService(
            ITranslationRepository translationRepository,
            IMemoryCache memoryCache)
        {
            _translationRepository = translationRepository;
            _memoryCache = memoryCache;
        }

        public async Task<TranslationBulkUpsertResponseDto> UpsertTranslationsAsync(
            IReadOnlyCollection<TranslationBulkUpsertItemDto> items,
            CancellationToken cancellationToken = default)
        {
            if (items.Count == 0)
            {
                throw new ArgumentException("At least one translation item is required.", nameof(items));
            }

            var sanitizedItems = SanitizeAndValidate(items);
            var result = await _translationRepository.UpsertTranslationsAsync(sanitizedItems, cancellationToken);

            foreach (var languageCode in result.AffectedLanguageCodes)
            {
                _memoryCache.Remove(GetCacheKey(languageCode));
            }

            return result;
        }

        public async Task<IReadOnlyList<TranslationKeyValueDto>> GetTranslationsByLanguageCodeAsync(
            string languageCode,
            CancellationToken cancellationToken = default)
        {
            var normalizedLanguageCode = NormalizeRequired(languageCode, nameof(languageCode));
            var cacheKey = GetCacheKey(normalizedLanguageCode);

            if (_memoryCache.TryGetValue<IReadOnlyList<TranslationKeyValueDto>>(cacheKey, out var cached))
            {
                return cached!;
            }

            var data = await _translationRepository.GetTranslationsByLanguageCodeAsync(
                normalizedLanguageCode,
                cancellationToken);

            var cacheOptions = new MemoryCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = CacheAbsoluteExpiration,
                SlidingExpiration = CacheSlidingExpiration
            };

            _memoryCache.Set(cacheKey, data, cacheOptions);
            return data;
        }

        private static List<TranslationBulkUpsertItemDto> SanitizeAndValidate(IReadOnlyCollection<TranslationBulkUpsertItemDto> items)
        {
            var deduped = new Dictionary<(string LanguageCode, string TranslationKey), TranslationBulkUpsertItemDto>();
            var row = 0;

            foreach (var item in items)
            {
                row++;
                if (item == null)
                {
                    throw new ArgumentException($"Item at index {row - 1} is null.", nameof(items));
                }

                var languageCode = NormalizeRequired(item.LanguageCode, $"items[{row - 1}].LanguageCode");
                var translationKey = NormalizeRequired(item.TranslationKey, $"items[{row - 1}].TranslationKey");
                var translationValue = NormalizeRequired(item.TranslationValue, $"items[{row - 1}].TranslationValue");

                deduped[(languageCode, translationKey)] = new TranslationBulkUpsertItemDto
                {
                    LanguageCode = languageCode,
                    TranslationKey = translationKey,
                    TranslationValue = translationValue
                };
            }

            return deduped.Values.ToList();
        }

        private static string NormalizeRequired(string? value, string fieldName)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException($"{fieldName} is required.");
            }

            return value.Trim();
        }

        private static string GetCacheKey(string languageCode)
        {
            return $"{CacheKeyPrefix}{languageCode.ToLowerInvariant()}";
        }
    }
}
