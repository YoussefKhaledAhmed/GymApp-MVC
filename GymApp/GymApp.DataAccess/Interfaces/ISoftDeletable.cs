// GymApp.DataAccess/Interfaces/ISoftDeletable.cs
namespace GymApp.DataAccess.Interfaces;

public interface ISoftDeletable
{
    bool IsDeleted { get; set; }
    DateTime? DeletedAt { get; set; }
}