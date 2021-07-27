using System;
using System.Linq;
using System.Threading.Tasks;
using Kinoshka.Contexts;
using Kinoshka.Models;
using Kinoshka.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Kinoshka.Controllers
{
    
    public class DictionariesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public DictionariesController(ApplicationDbContext context,
            UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        #region Statuses

        [HttpGet]
        public async Task<IActionResult> DisplayStatusList()
        {
            return View(_context.Statuses.Where(x => !x.Deleted).AsEnumerable());
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateStatusRequest request)
        {
            var status = new JobStatus
            {
                Title = request.Title,
                Icon = request.Icon,
            };
            await _context.Statuses.AddAsync(status);
            await _context.SaveChangesAsync();
            
            return RedirectToAction("DisplayStatusList");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var status = await _context.Statuses.FirstOrDefaultAsync(x => x.Id == id);
            if (status is null) return NotFound();
            var editModel = new EditStatusRequest
            {
                Id = status.Id,
                Title = status.Title,
                Icon = status.Icon
            };
            return View(editModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditStatusRequest request)
        {
            var status = await _context.Statuses.FirstOrDefaultAsync(x => x.Id == request.Id);
            if (status is null) return NotFound();
            status.Title = request.Title;
            status.Icon = request.Icon;
            status.ModifiedAt = DateTime.Now;
            status.ModifiedBy = "admin";
            await Task.Run(() => _context.Statuses.Update(status));
            await _context.SaveChangesAsync();
            return RedirectToAction("DisplayStatusList");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var status = await _context.Statuses.FirstOrDefaultAsync(x => x.Id == id);
            if (status is null) return NotFound();
            status.Deleted = true;
            status.DeletedAt = DateTime.Now;
            status.DeletedBy = "admin";
            await Task.Run(() => _context.Statuses.Update(status));
            await _context.SaveChangesAsync();
            return RedirectToAction("DisplayStatusList");
        }

        #endregion
    }
}