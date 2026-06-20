using GymApp.BusinessLogic.Services.DTOs.Members;
using GymApp.Shared.ResultPattern;

namespace GymApp.BusinessLogic.Services.MemberServices;

public interface IMemberService
{
    public Task<Result<List<MemberDto>>> GetAllAsync(string[]? includes = null, CancellationToken cancellationToken = default);

    public Task<Result<bool>> CreateAsync(MemberDto member, CancellationToken cancellationToken);
}
