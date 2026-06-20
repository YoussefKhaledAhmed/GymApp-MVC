using GymApp.Shared.Enums;
using System.ComponentModel.DataAnnotations;

namespace GymApp.Presentation.ViewModels.HealthRecord;

public class HealthRecordViewModel
{
    [Required(ErrorMessage = "Height is required")]
    [Range(50, 250, ErrorMessage = "Height must be between 50, and 250")]
    public int Height { get; set; }

    [Required(ErrorMessage = "Weight is required")]
    [Range(30, 250, ErrorMessage = "Weight must be between 30, and 250")]
    public int Weight { get; set; }

    [Required(ErrorMessage = "Blood type is required")]
    public BloodTypeEnum BloodType { get; set; } = default!;

    public string Note { get; set; } = default!;
}
