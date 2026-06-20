using GymApp.BusinessLogic.Services.DTOs.PLans;
using GymApp.DataAccess.Repository.PlanRepo;
using GymApp.Shared.ResultPattern;

namespace GymApp.BusinessLogic.Services.Plan;

public class PlanService(IPlanRepository planRepo) : IPlanService
{
    private readonly IPlanRepository _planRepo = planRepo;
    public async Task<Result<List<PlanDto>>> GetAllAsync(string[]? includes = null, CancellationToken cancellationToken = default)
    {
        var plans = await _planRepo.GetAllAsync(includes, cancellationToken);
        var mappedPlans = plans.Select(p => new PlanDto
        {
            Id = p.Id,
            Name = p.Name,
            Description = p.Description,
            DurationDays = p.DurationDays,
            IsActive = p.IsActive,
            Price = p.Price
        }).ToList();
        return Result<List<PlanDto>>.Success(mappedPlans);
    }

    public async Task<Result<PlanDto>> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        var plan = await _planRepo.GetByIdAsync(id, cancellationToken);

        if (plan is null) return Result<PlanDto>.Failure($"plan with {id} not found");

        var mappedPlan = new PlanDto
        {
            Name = plan.Name,
            Description = plan.Description,
            DurationDays = plan.DurationDays,
            IsActive = plan.IsActive,
            Price = plan.Price
        };

        return Result<PlanDto>.Success(mappedPlan);
    }
}
