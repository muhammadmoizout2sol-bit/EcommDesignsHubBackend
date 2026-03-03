using EcommDesignsHub.Data;
using EcommDesignsHub.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EcommDesignsHub.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectApiController : ControllerBase
    {
        private readonly IProjectRepository _repo;
        private readonly IWebHostEnvironment _env;

        public ProjectApiController(IProjectRepository repo, IWebHostEnvironment env)
        {
            _repo = repo;
            _env = env;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var projects = await _repo.GetAllForSite();

            if (projects == null || !projects.Any())
                return NotFound("No projects found");

            return Ok(projects);
        }
        [HttpGet("GetCategory")]
        public async Task<IActionResult> GetCategory()
        {
            var categories = await _repo.GetAllCategoryForSite();

            if (categories == null || !categories.Any())
                return NotFound("No projects found");

            return Ok(categories);
        }
    }
}
