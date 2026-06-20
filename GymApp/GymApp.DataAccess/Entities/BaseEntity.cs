namespace GymApp.DataAccess.Entities;

public class BaseEntity
{
    public int Id { get; set; }
    // AuditColumns
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }
    // SoftDelete
    public bool IsDeleted { get; set; }
}
