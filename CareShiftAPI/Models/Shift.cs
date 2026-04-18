namespace CareShiftAPI.Models
{
    public class Shift
    {
        public int Id { get; set; }
        public DateTime ShiftDate { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public string Location { get; set; } = string.Empty;
        public string Status { get; set; } = "Scheduled";//Scheduled/Completed/Cancelled

        //Foreign key - links this shift to a care worker
        public int CareWorkerId { get; set; }
        public CareWorker CareWorker { get; set; } = null;
    }
}
