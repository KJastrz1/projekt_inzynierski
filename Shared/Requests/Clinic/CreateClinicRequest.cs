using System.ComponentModel.DataAnnotations;

namespace Shared.Requests.Clinic;
public class CreateClinicRequest
{
    [Required(ErrorMessage = "Address is required.")]
    [StringLength(200, ErrorMessage = "Address cannot be longer than 200 characters.")]
    public required string Address { get; set; }

    [Required(ErrorMessage = "Phone number is required.")]
    [StringLength(15, ErrorMessage = "Phone number cannot be longer than 15 characters.")]
    public required string PhoneNumber { get; set; }
}
