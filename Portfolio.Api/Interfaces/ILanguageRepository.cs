using Portfolio.Api.Models.DTOs;

namespace Portfolio.Api.Interfaces
{
    public interface ILanguageRepository
    {
        Task<List<LanguageDto>> GetLanguagesAsync(bool includeInactive, CancellationToken cancellationToken = default);
    }
}
