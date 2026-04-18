using System.ComponentModel.DataAnnotations;

namespace CareShiftAPI.Models

{
    public class CareWorker
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string FullName { get; set;  } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set;  } = string.Empty;

        public string PasswordHash {  get; set; }= string.Empty; //never store plain text!

        public string Role {  get; set; } = "Worker"; //Worker/Supervisor/Admin

        public string PhoneNumber {  get; set; } = string.Empty;

        public bool IsActive { get; set; } = true;
        public DateTime CreatedAt { get; set; }= DateTime.Now;

        //Navigation properties - EF Core uses these to create the JOIN
        public ICollection<Shift> Shifts { get; set; } = new List<Shift>();
        public ICollection<Availability> Availabilities { get; set; } = new List<Availability>();


    }
}

