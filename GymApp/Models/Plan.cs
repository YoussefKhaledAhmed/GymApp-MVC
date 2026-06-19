namespace GymApp.Models;

public class Plan
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
    public decimal Price { get; set; }
    public short DurationDays { get; set; }
    public bool IsActive { get; set; }

    /* -> Audit columns: */
    public DateTime CreatedAt { get; set; }

    // nullable as it should be when the plan is firstly created
    public DateTime? LastUpdatedAt { get; set; } 

    /* -> Soft deletion: */
    public bool IsDeleted { get; set; }

    // nullable as it should be when the plan does exist
    public DateTime? DeletedAt { get; set; }
}
