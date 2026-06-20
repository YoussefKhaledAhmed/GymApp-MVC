using GymApp.Shared.Enums;

namespace GymApp.BusinessLogic.Services.DTOs.HealthRecords;

public class HealthRecordsDto
{
    public int Height { get; set; }

    public int Weight { get; set; }

    public BloodTypeEnum BloodType { get; set; } = default!;

    public string Note { get; set; } = default!;
}
