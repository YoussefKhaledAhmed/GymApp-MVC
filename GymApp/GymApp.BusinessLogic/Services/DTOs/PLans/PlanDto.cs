namespace GymApp.BusinessLogic.Services.DTOs.PLans;

public class PlanDto
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
    public decimal Price { get; set; }
    public short DurationDays { get; set; }
    public bool IsActive { get; set; }
}
