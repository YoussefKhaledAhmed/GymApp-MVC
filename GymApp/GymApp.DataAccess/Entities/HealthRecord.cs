
using GymApp.Shared.Enums;

namespace GymApp.DataAccess.Entities;

public class HealthRecord : BaseEntity
{
    public int Height { get; set; }
    public int Weight { get; set; }
    public BloodTypeEnum BloodType { get; set; }
    public string Note { get; set; } = default!;

    // Relations:
    // 1. Member:
    // - navigation object.
    public Member Member { get; set; } = default!;

    // - foreign key
    public int MemberId { get; set; }

}
