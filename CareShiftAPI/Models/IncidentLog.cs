namespace CareShiftAPI.Models
{
    public class IncidentLog
    {
        public int Id { get; set; }
        public DateTime IncidentDate { get; set; }
        public string Description { get; set; } = string.Empty;
        public string Severity { get; set; } = "Low"; //Low /Medium /High
        public int ReportedByWorkerId { get; set; }
        public CareWorker ReportedByWorker { get; set; } = null!;
        public DateTime CreatedAt { get; set; }= DateTime.Now;
    }
}
