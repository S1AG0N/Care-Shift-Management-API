namespace CareShiftAPI.Models
{
    public class Availability
    {
        public int Id { get; set; }

        public DateTime AvailableDate { get; set; }

        public bool IsAvailable { get; set; } = true;

        // Foreign key
        public int CareWorkerId { get; set; }

        public CareWorker CareWorker { get; set; } = null!;
    }
}