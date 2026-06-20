namespace GymApp.DataAccess.Entities;

public class Plan : BaseEntity
{
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
    public decimal Price { get; set; }
    public short DurationDays { get; set; }
    public bool IsActive { get; set; }

    // Relations:
    // 1. Memberships:
    public ICollection<Membership> Memberships { get; set; } = [];
}
