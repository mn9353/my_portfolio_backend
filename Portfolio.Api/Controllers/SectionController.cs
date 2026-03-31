using Microsoft.AspNetCore.Mvc;
using Portfolio.Api.Interfaces;

namespace Portfolio.Api.Controllers
{
    [ApiController]
    [Route("api/sections")]
    public class SectionsController : ControllerBase
    {
        private readonly ISectionService _sectionService;

        public SectionsController(ISectionService sectionService)
        {
            _sectionService = sectionService;
        }

        [HttpGet("{portfolioId}")]
        public async Task<IActionResult> GetSections(long portfolioId)
        {
            var result = await _sectionService.GetSectionsByPortfolioIdAsync(portfolioId);

            return Ok(result);
        }
    }
}
