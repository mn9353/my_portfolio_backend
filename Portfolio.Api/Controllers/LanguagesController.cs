using Microsoft.AspNetCore.Mvc;
using Portfolio.Api.Interfaces;

namespace Portfolio.Api.Controllers
{
    [ApiController]
    [Route("api/languages")]
    public class LanguagesController : ControllerBase
    {
        private readonly ILanguageService _languageService;

        public LanguagesController(ILanguageService languageService)
        {
            _languageService = languageService;
        }

        [HttpGet]
        public async Task<IActionResult> GetLanguages([FromQuery] bool includeInactive = false, CancellationToken cancellationToken = default)
        {
            var result = await _languageService.GetLanguagesAsync(includeInactive, cancellationToken);
            return Ok(result);
        }
    }
}
