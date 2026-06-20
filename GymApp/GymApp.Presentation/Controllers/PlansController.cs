using GymApp.BusinessLogic.Services.Plan;
using GymApp.Presentation.ViewModels.Plans;
using Microsoft.AspNetCore.Mvc;

namespace GymApp.Presentation.Controllers;

public class PlansController(IPlanService planService) : Controller
{
    private readonly IPlanService _planService = planService;

    public async Task<IActionResult> Index()
    {
        var result = await _planService.GetAllAsync();

        if (!result.IsSuccess)
        {
            return StatusCode(500, result.ErrMsg);
        }

        var plansViewModel = result.Value!.Select(p => new PlanViewModel
        {
            Id = p.Id,
            Description = p.Description,
            DurationDays = p.DurationDays,
            IsActive = p.IsActive,
            Name = p.Name,
            Price = p.Price
        }).ToList();

        return View(plansViewModel);
    }

    [HttpGet("Details/{id}")]
    public async Task<IActionResult> Details(int id)
    {
        if (id <= 0)
        {
            return NotFound();
        }

        var result = await _planService.GetByIdAsync(id);

        if (!result.IsSuccess)
        {
            return StatusCode(500, result.ErrMsg);
        }

        var plan = result.Value;

        if (plan is null)
        {
            return RedirectToAction(nameof(Index));
        }

        var planViewMode = new PlanViewModel
        {
            Id = plan.Id,
            Description = plan.Description,
            DurationDays = plan.DurationDays,
            IsActive = plan.IsActive,
            Name = plan.Name,
            Price = plan.Price
        };

        return View(planViewMode);
    }
}
