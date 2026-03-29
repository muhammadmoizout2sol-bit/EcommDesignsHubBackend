using EcommDesignsHub.Data;
using EcommDesignsHub.Models;
using Microsoft.AspNetCore.Mvc;

namespace EcommDesignsHub.Controllers
{
    public class JobController : Controller
    {
        private readonly ApplicationDbContext _context;

        public JobController(ApplicationDbContext context)
        {
            _context = context;
        }




        public IActionResult Index()
        {
            var jobs = _context.Jobs.ToList();
            return View(jobs);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Job job)
        {
            _context.Jobs.Add(job);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var job = _context.Jobs.Find(id);
            return View(job);
        }

        [HttpPost]
        public IActionResult Edit(Job job)
        {
            _context.Jobs.Update(job);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            var job = _context.Jobs.Find(id);
            if (job == null) return NotFound();
            return View(job);
        }

        public IActionResult Applicants(int id)
        {
            var job = _context.Jobs.Find(id);
            if (job == null) return NotFound();

            var applicants = _context.Applications
                .Where(a => a.JobId == id)
                .OrderByDescending(a => a.AppliedDate)
                .ToList();

            var vm = new Models.ViewModel.JobApplicantsViewModel
            {
                Job = job,
                Applications = applicants
            };

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateApplicationStatus(int applicationId, int jobId, string status)
        {
            var application = _context.Applications.Find(applicationId);
            if (application == null) return NotFound();

            status = (status ?? "").Trim();
            if (string.IsNullOrEmpty(status))
                return BadRequest("Status is required.");

            application.Status = status;
            _context.SaveChanges();

            TempData["success"] = "Application status updated to " + status + ".";

            return RedirectToAction("Applicants", new { id = jobId });
        }
    }
}
