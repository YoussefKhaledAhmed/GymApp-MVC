using GymApp.DataAccess.Entities.OwnedEntites;
using GymApp.Shared.Enums;

namespace GymApp.DataAccess.Entities;

public class Member : UserBaseEntity
{
    public string Name { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string Phone { get; set; } = default!;
    public DateTime DateOfBirth { get; set; } = default!;
    public GenderEnum Gender { get; set; } = default!;
    public AddressDetails Address { get; set; } = default!;
    public DateTime JoinDate { get; set; }
    public string? PhotoURL { get; set; } = default!;

    // relations:

    // 1. HealthRecord:
    // navigation object:
    public HealthRecord HealthRecord { get; set; } = default!;

    // 2. Bookings: (booked sessions)
    public ICollection<Booking> Bookings { get; set; } = [];

    // 3. Memberships: (subscribed plans)
    public ICollection<Membership> MemberShips { get; set; } = [];



}
