namespace GymApp.DataAccess.Entities;

public class Session : BaseEntity
{
    public string Description { get; set; } = default!;
    public int Capacity { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }

    // Relations:
    // 1. Trainer:
    // navigation object
    public Trainer Trainer { get; set; } = default!;
    // foriegn key
    public int TrainerId { get; set; }

    // 2. Category:
    // navigation object
    public Category Category { get; set; } = default!;
    // foriegn key
    public int CategoryId { get; set; }

    // 3. Booking:
    public ICollection<Booking> Bookings { get; set; } = [];
}
