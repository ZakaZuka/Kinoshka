using System;
using System.Threading.Tasks;
using Kinoshka.Contexts;
using Kinoshka.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Kinoshka.Controllers
{
    public class ProjectsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public ProjectsController(ApplicationDbContext context,
            UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var project = new Project();
            return View(project);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] Project project)
        {
            if (project is null) throw new Exception("model is null");

            var user = await _userManager.GetUserAsync(User);
            project.AuthorId = user.Id;
            await _context.Projects.AddAsync(project);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index", "Home");
        }
    }
}