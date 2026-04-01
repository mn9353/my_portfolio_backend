using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using Portfolio.Api.Interfaces;
using Portfolio.Api.Models.DTOs;
using System.Security.Cryptography;
using System.Text;

namespace Portfolio.Api.Controllers
{
    [ApiController]
    [Route("api/translations")]
    public class TranslationsController : ControllerBase
    {
        private const string ApiKeyHeaderName = "X-Api-Key";
        private const string WriteApiKeyConfigPath = "Security:TranslationWriteApiKey";

        private readonly ITranslationService _translationService;
        private readonly string? _translationWriteApiKey;

        public TranslationsController(ITranslationService translationService, IConfiguration configuration)
        {
            _translationService = translationService;
            _translationWriteApiKey = configuration[WriteApiKeyConfigPath]?.Trim();
        }

        [HttpPost("bulk-upsert")]
        [EnableRateLimiting("fixed")]
        public async Task<IActionResult> BulkUpsert(
            [FromBody] List<TranslationBulkUpsertItemDto> items,
            CancellationToken cancellationToken)
        {
            var authResult = ValidateWriteAccess();
            if (authResult != null)
            {
                return authResult;
            }

            if (items == null || items.Count == 0)
            {
                return BadRequest("Request body must include at least one translation item.");
            }

            try
            {
                var result = await _translationService.UpsertTranslationsAsync(items, cancellationToken);
                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        private IActionResult? ValidateWriteAccess()
        {
            if (string.IsNullOrWhiteSpace(_translationWriteApiKey))
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable,
                    "Translation write API key is not configured.");
            }

            if (!Request.Headers.TryGetValue(ApiKeyHeaderName, out var providedApiKeys))
            {
                return Unauthorized($"Missing {ApiKeyHeaderName} header.");
            }

            var providedApiKey = providedApiKeys.FirstOrDefault()?.Trim();
            if (string.IsNullOrWhiteSpace(providedApiKey))
            {
                return Unauthorized($"Missing {ApiKeyHeaderName} header.");
            }

            if (!SecureEquals(_translationWriteApiKey, providedApiKey))
            {
                return Unauthorized("Invalid API key.");
            }

            return null;
        }

        private static bool SecureEquals(string expected, string provided)
        {
            var expectedBytes = Encoding.UTF8.GetBytes(expected);
            var providedBytes = Encoding.UTF8.GetBytes(provided);
            return CryptographicOperations.FixedTimeEquals(expectedBytes, providedBytes);
        }

        [HttpGet("{languageCode}")]
        public async Task<IActionResult> GetByLanguageCode(string languageCode, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _translationService.GetTranslationsByLanguageCodeAsync(languageCode, cancellationToken);
                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
