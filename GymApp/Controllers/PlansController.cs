using GymApp.Data.Contexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GymApp.Controllers
{
    public class PlansController : Controller
    {
        GymDbContext _context = new GymDbContext(); 
        public async Task<IActionResult> Index()
        {
            var plans = await _context.Plans.ToListAsync();

            return View(plans);
        }

        [HttpGet("Details/{id}")]
        public async Task<IActionResult> Details(int id)
        {
            if(id <= 0)
            {
                return NotFound();
            }

            var plan = await _context.Plans.FirstOrDefaultAsync(p => p.Id == id);

            if(plan is null)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(plan);
        }
    }
}
