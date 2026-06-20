using GymApp.DataAccess.Entities.OwnedEntites;
using GymApp.Shared.Enums;

namespace GymApp.DataAccess.Entities;

public class Trainer : UserBaseEntity
{
    public string Name { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string Phone { get; set; } = default!;
    public DateTime DateOfBirth { get; set; } = default!;
    public GenderEnum Gender { get; set; } = default!;
    public AddressDetails Address { get; set; } = default!;
    public FitnessSpecialtyEnum Specialty { get; set; }
    public DateTime HireDate { get; set; }

    // Relations:
    // 1. Sessions
    // ICollection<session>
    public ICollection<Session> Sessions { get; set; } = [];

}
