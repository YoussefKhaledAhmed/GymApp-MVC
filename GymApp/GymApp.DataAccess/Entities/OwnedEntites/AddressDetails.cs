using Microsoft.EntityFrameworkCore;

namespace GymApp.DataAccess.Entities.OwnedEntites;

[Owned]
public class AddressDetails
{
    public int BuildingNo { get; set; }
    public string Street { get; set; } = default!;
    public string City { get; set; } = default!;
}
