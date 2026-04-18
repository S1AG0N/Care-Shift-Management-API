using System.ComponentModel.DataAnnotations;

namespace CareShiftAPI.DTOs
{
    //This is what we RECEIVE when creating a worker 
    public class CreateWorkerDto
    {
        [Required]
        public string FullName { get; set; } = string.Empty;
        [Required]
        [EmailAddress]
        public string Email { get; set; }= string.Empty;
        [Required]
        [MinLength(8)]
        public string Password { get; set; }=string.Empty;//Plain text-we hash before saving
        public string PhoneNumber { get; set; } =string.Empty;

    }
}
