namespace GymApp.BusinessLogic.Services.DTOs.AddressDetails;

public class AddressDetailsDto
{
    public int BuildingNo { get; set; }
    public string Street { get; set; } = default!;
    public string City { get; set; } = default!;
}
