using EcommDesignsHub.Data;
using EcommDesignsHub.Models;
using EcommDesignsHub.Models.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace EcommDesignsHub.Controllers
{
    [ApiController]
    [Route("api/applications")]
    public class ApplicationController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _env;

        public ApplicationController(ApplicationDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        [HttpPost]
        public async Task<IActionResult> Apply([FromForm] ApplicationDTO dto)
        {
            var filePath = "/uploads/";

            if (dto.Resume != null)
            {
                string folder = Path.Combine(_env.WebRootPath, "uploads");
                Directory.CreateDirectory(folder);

                string fileName = Guid.NewGuid() + Path.GetExtension(dto.Resume.FileName);
                string path = Path.Combine(folder, fileName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await dto.Resume.CopyToAsync(stream);
                }

                 filePath =  "/uploads/" + fileName;
            }

            var app = new Application
            {
                FullName = dto.FullName,
                Email = dto.Email,
                Phone = dto.Phone,
                ResumePath = filePath,
                JobId = dto.JobId
            };

            _context.Applications.Add(app);
            await _context.SaveChangesAsync();

            return Ok(app);
        }
    }
}
