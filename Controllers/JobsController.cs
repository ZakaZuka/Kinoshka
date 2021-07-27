using System;
using System.Threading.Tasks;
using Kinoshka.Contexts;
using Kinoshka.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Kinoshka.Controllers
{
    public class JobsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public JobsController(ApplicationDbContext context,
            UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index(string projectId)
        {
            if (string.IsNullOrEmpty(projectId)) throw new NullReferenceException("Project id can not be null");

            var project = new Project();

            if (Guid.TryParse(projectId, out var id))
                project = await _context.Projects
                    .Include(x => x.Author)
                    .Include(x => x.Jobs)
                    .FirstOrDefaultAsync(x => x.Id == id);

            return View(project);
        }

        [HttpGet]
        public async Task<IActionResult> Create(string projectId)
        {
            if (string.IsNullOrEmpty(projectId)) throw new NullReferenceException("Project id can not be null");

            Guid.TryParse(projectId, out var id);
            var job = new Job();
            job.ProjectId = id;
            return View(job);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] Job job)
        {
            if (job is null) throw new Exception("Model can not be null");

            var user = await _userManager.GetUserAsync(User);
            job.AuthorId = user.Id;
            job.StatusId = 1;
            await _context.Jobs.AddAsync(job);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Jobs", new {projectId = job.ProjectId});
        }
    }
}