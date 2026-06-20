using GymApp.Shared.Enums;

namespace GymApp.DataAccess.Entities.OwnedEntites;

public class PersonalInfo
{
    public string Name { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string Phone { get; set; } = default!;
    public DateTime DateOfBirth { get; set; } = default!;
    public GenderEnum Gender { get; set; } = default!;
    public AddressDetails Address { get; set; } = default!;

}
