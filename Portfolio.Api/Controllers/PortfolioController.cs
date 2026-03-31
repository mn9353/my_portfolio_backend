using Microsoft.AspNetCore.Mvc;
using Portfolio.Api.Interfaces;

namespace Portfolio.Api.Controllers
{
    [ApiController]
    [Route("api/portfolio")]
    public class PortfolioController : ControllerBase
    {
        private readonly IPortfolioService _portfolioService;

        public PortfolioController(IPortfolioService portfolioService)
        {
            _portfolioService = portfolioService;
        }

        [HttpGet("basic/{portfolioId}")]
        public async Task<IActionResult> GetBasicPortfolio(long portfolioId)
        {
            var result = await _portfolioService.GetPortfolioBasicAsync(portfolioId);

            if (result == null)
                return NotFound($"Portfolio with ID {portfolioId} not found.");

            return Ok(result);
        }

        [HttpGet("projects/{portfolioId}")]
        public async Task<IActionResult> GetProjects(long portfolioId)
        {
            var result = await _portfolioService.GetProjectsAsync(portfolioId);
            return Ok(result);
        }

        [HttpGet("experiences/{portfolioId}")]
        public async Task<IActionResult> GetExperiences(long portfolioId)
        {
            var result = await _portfolioService.GetExperiencesAsync(portfolioId);
            return Ok(result);
        }

        [HttpGet("education/{portfolioId}")]
        public async Task<IActionResult> GetEducation(long portfolioId)
        {
            var result = await _portfolioService.GetEducationAsync(portfolioId);
            return Ok(result);
        }

        [HttpGet("skills/{portfolioId}")]
        public async Task<IActionResult> GetSkills(long portfolioId)
        {
            var result = await _portfolioService.GetSkillsAsync(portfolioId);
            return Ok(result);
        }

        [HttpGet("certifications/{portfolioId}")]
        public async Task<IActionResult> GetCertifications(long portfolioId)
        {
            var result = await _portfolioService.GetCertificationsAsync(portfolioId);
            return Ok(result);
        }

        [HttpGet("achievements/{portfolioId}")]
        public async Task<IActionResult> GetAchievements(long portfolioId)
        {
            var result = await _portfolioService.GetAchievementsAsync(portfolioId);
            return Ok(result);
        }

        [HttpGet("social-links/{portfolioId}")]
        public async Task<IActionResult> GetSocialLinks(long portfolioId)
        {
            var result = await _portfolioService.GetSocialLinksAsync(portfolioId);
            return Ok(result);
        }

        [HttpGet("testimonials/{portfolioId}")]
        public async Task<IActionResult> GetTestimonials(long portfolioId)
        {
            var result = await _portfolioService.GetTestimonialsAsync(portfolioId);
            return Ok(result);
        }
    }
}
