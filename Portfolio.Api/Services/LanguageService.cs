using Portfolio.Api.Interfaces;
using Portfolio.Api.Models.DTOs;

namespace Portfolio.Api.Services
{
    public class LanguageService : ILanguageService
    {
        private readonly ILanguageRepository _languageRepository;

        public LanguageService(ILanguageRepository languageRepository)
        {
            _languageRepository = languageRepository;
        }

        public async Task<IReadOnlyList<LanguageDto>> GetLanguagesAsync(bool includeInactive, CancellationToken cancellationToken = default)
        {
            return await _languageRepository.GetLanguagesAsync(includeInactive, cancellationToken);
        }
    }
}
