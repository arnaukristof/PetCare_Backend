using Microsoft.EntityFrameworkCore;
using PetCare.Models.Entities;

namespace PetCare.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Worker and DaysOfWeek Connections
            modelBuilder.Entity<Worker_DaysOfWeek>()
                .HasOne(w => w.Worker)
                .WithMany(wd => wd.Worker_DaysOfWeeks)
                .HasForeignKey(wi => wi.WorkerId);

            modelBuilder.Entity<Worker_DaysOfWeek>()
                .HasOne(w => w.DaysOfWeek)
                .WithMany(wd => wd.Worker_DaysOfWeeks)
                .HasForeignKey(wi => wi.DaysOfWeekId);

            //Worker and PetType Connections
            modelBuilder.Entity<Worker_PetType>()
                .HasOne(w => w.Worker)
                .WithMany(wd => wd.Worker_PetTypes)
                .HasForeignKey(wi => wi.WorkerId);

            modelBuilder.Entity<Worker_PetType>()
                .HasOne(w => w.PetType)
                .WithMany(wd => wd.Worker_PetTypes)
                .HasForeignKey(wi => wi.PetTypeId);
        }
        public DbSet<Pet> Pets { get; set; }
        public DbSet<PetSize> PetSizes { get; set; }
        public DbSet<PetType> PetTypes { get; set; }
        public DbSet<PetBreed> PetBreeds { get; set; }
        public DbSet<Worker> Workers { get; set; }
        public DbSet<DaysOfWeek> DaysOfWeeks { get; set; }
        public DbSet<Worker_DaysOfWeek> Worker_DaysOfWeeks { get; set; }
        public DbSet<Worker_PetType> Worker_PetTypes { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<ScheduleType> ScheduleTypes { get; set; }
        public DbSet<Image> Images { get; set; }
    }
}
