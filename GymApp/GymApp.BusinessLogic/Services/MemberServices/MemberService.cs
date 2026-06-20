using GymApp.BusinessLogic.Services.DTOs.Members;
using GymApp.BusinessLogic.Services.DTOs.AddressDetails;
using GymApp.DataAccess.Repository.MemberRepo;
using GymApp.Shared.ResultPattern;
using GymApp.DataAccess.Entities;
using GymApp.DataAccess.Entities.OwnedEntites;
using GymApp.Shared.Enums;

namespace GymApp.BusinessLogic.Services.MemberServices;

public class MemberService(IMemberRepository memberRepo) : IMemberService
{
    private readonly IMemberRepository _memberRepo = memberRepo;


    public async Task<Result<List<MemberDto>>> GetAllAsync(string[]? includes = null, CancellationToken cancellationToken = default)
    {
        var members = await _memberRepo.GetAllAsync(includes, cancellationToken);

        if (members is null) return Result<List<MemberDto>>.Success([]);

        var mappedMember = members.Select(m => new MemberDto
        {
            Id = m.Id,
            Name = m.Name,
            Address = new AddressDetailsDto
            {
                BuildingNo = m.Address.BuildingNo,
                City = m.Address.City,
                Street = m.Address.Street
            },
            DateOfBirth = m.DateOfBirth,
            Email = m.Email,
            Gender = m.Gender,
            JoinDate = m.JoinDate,
            Phone = m.Phone,
            PhotoURL = m.PhotoURL
        }).ToList();
        return Result<List<MemberDto>>.Success(mappedMember);
    }
    public async Task<Result<bool>> CreateAsync(MemberDto model, CancellationToken cancellationToken)
    {
        var name = model.Name.Trim().ToLower();
        var email = model.Email.Trim().ToLower();

        if (await _memberRepo.ExistAsync(m => m.Email == email, cancellationToken))
        {
            return Result<bool>.Failure("Email exists" , nameof(MemberDto.Email));
        }
        if (await _memberRepo.ExistAsync(m => m.Phone == model.Phone, cancellationToken))
        {
            return Result<bool>.Failure("Phone exists", nameof(MemberDto.Phone));
        }
        if (!Enum.IsDefined(typeof(GenderEnum), model.Gender))
        {
            return Result<bool>.Failure(errMsg: "Gender isn't valid", nameof(MemberDto.Gender));
        }
        if (!Enum.IsDefined(typeof(BloodTypeEnum), model.HealthRecordsDto.BloodType))
        {
            return Result<bool>.Failure(errMsg: "bloodType isn't valid", nameof(MemberDto.HealthRecordsDto.BloodType));
        }


        var member = new Member
        {
            Name = name,
            Phone = model.Phone,
            Address = new AddressDetails
            {
                BuildingNo = model.Address.BuildingNo,
                City = model.Address.City,
                Street = model.Address.Street
            },
            Email = email,
            Gender = model.Gender,
            DateOfBirth = model.DateOfBirth,
            JoinDate = DateTime.UtcNow,
            HealthRecord = new HealthRecord
            {
                BloodType = model.HealthRecordsDto.BloodType,
                Height = model.HealthRecordsDto.Height,
                Weight = model.HealthRecordsDto.Weight,
                Note = model.HealthRecordsDto.Note
            },
            PhotoURL = model.PhotoURL
        };

        await _memberRepo.Add(member , cancellationToken);

        await _memberRepo.SaveChangesAsync(cancellationToken);

        return Result<bool>.Success(true);
    }
}
