using Portfolio.Api.Models.DTOs;

namespace Portfolio.Api.Interfaces
{
    public interface ILanguageService
    {
        Task<IReadOnlyList<LanguageDto>> GetLanguagesAsync(bool includeInactive, CancellationToken cancellationToken = default);
    }
}
