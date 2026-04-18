using Microsoft.EntityFrameworkCore;
using CareShiftAPI.Models;

namespace CareShiftAPI.Data
{
    public class AppDbContext:DbContext
    {
        //Constructor- passes otions upto the base DbContext class
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        //Each DbSet<T> becomes a table in the database
        public  DbSet<CareWorker> CareWorkers{ get; set; }
        public  DbSet<Shift> Shifts { get; set; }
        public  DbSet<IncidentLog> IncidentLogs{ get; set; }
        public  DbSet<Availability> Availabilities { get; set; }
    }
}
