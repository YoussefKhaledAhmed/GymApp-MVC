using GymApp.BusinessLogic.Services.DTOs.AddressDetails;
using GymApp.BusinessLogic.Services.DTOs.HealthRecords;
using GymApp.Shared.Enums;


namespace GymApp.BusinessLogic.Services.DTOs.Members;

public class MemberDto
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string Phone { get; set; } = default!;
    public DateTime DateOfBirth { get; set; } = default!;
    public GenderEnum Gender { get; set; } = default!;
    public AddressDetailsDto Address { get; set; } = default!;
    public DateTime JoinDate { get; set; }
    public string? PhotoURL { get; set; } = default!;
    public HealthRecordsDto HealthRecordsDto { get; set; } = default!;

}
