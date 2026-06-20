namespace GymApp.DataAccess.Entities;

public class Membership : BaseEntity
{
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }

    public Member Member { get; set; } = null!;
    public int MemberId { get; set; }
    public Plan Plan { get; set; } = null!;
    public int PlanId { get; set; }


}
