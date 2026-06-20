namespace GymApp.DataAccess.Entities;

public class Category : BaseEntity
{
    public string Name { get; set; } = default!;

    // Relations:
    // 1. Sessions:
    // ICollection<session>
    public ICollection<Session> Sessions { get; set; } = [];
}
