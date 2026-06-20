namespace GymApp.DataAccess.Entities;

public class Booking : BaseEntity
{
    public DateTime BookingDay { get; set; }
    public bool IsAttended { get; set; }

    public Member Member { get; set; } = default!;
    public int MemberId { get; set; }
    public Session Session { get; set; } = default!;
    public int SessionId { get; set; }
}
