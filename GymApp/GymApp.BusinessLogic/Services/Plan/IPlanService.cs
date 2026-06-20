using GymApp.BusinessLogic.Services.DTOs.PLans;
using GymApp.Shared.ResultPattern;


namespace GymApp.BusinessLogic.Services.Plan;

public interface IPlanService
{
    public Task<Result<List<PlanDto>>> GetAllAsync(string[]? includes = null, CancellationToken cancellationToken = default);
    public Task<Result<PlanDto>> GetByIdAsync(int id, CancellationToken cancellationToken = default);


}
