using GymApp.Presentation.ViewModels.HealthRecord;
using GymApp.Shared.Enums;
using System.ComponentModel.DataAnnotations;

namespace GymApp.Presentation.ViewModels.Members;

public class MemberCreateViewModel
{
    [Required(ErrorMessage = "Name is Required")]
    [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage ="Name can only contain letters and spaces")]
    public string Name { get; set; } = default!;

    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Invalid email format")]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; } = default!;

    [Required(ErrorMessage = "Phone is required")]
    [Phone(ErrorMessage ="Invalid phone number")]
    [RegularExpression(@"^(010|011|012|015)\d{8}$" , ErrorMessage = "The phone number must be an egyptain mobile number")]
    [DataType(DataType.PhoneNumber)]
    public string Phone { get; set; } = default!;

    [Required(ErrorMessage ="Date of birth is required")]
    [DataType(DataType.Date)]
    public DateOnly DateOfBirth { get; set; }

    [Required(ErrorMessage = "Gender is required")]
    public GenderEnum Gender { get; set; } = default!;

    [Required(ErrorMessage ="Building number is required")]
    [Range(1,9000, ErrorMessage ="building number must be between 0 and 9000")]
    public int BuildingNumber { get; set; }

    [Required(ErrorMessage ="Street is required")]
    [StringLength(150 , MinimumLength =2 , ErrorMessage ="Street must be between 2 and 150 characters")]
    [RegularExpression(@"^[a-zA-Z0-9\s]+$", ErrorMessage ="Street can contain letters, numbers, and spaces")]
    public string Street { get; set; } = default!;

    [Required(ErrorMessage ="City is required")]
    [StringLength(100, MinimumLength = 2, ErrorMessage = "City must be between 2 and 100 characters")]
    [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "City can contain letters, and spaces")]
    public string City { get; set; } = default!;

    [Required(ErrorMessage ="Health record is required")]
    public HealthRecordViewModel HealthRecordViewModel { get; set; } = default!;
}