using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<TeamMember.Model.TeamMember> TeamMembers { get; set; }
        public DbSet<Team.Model.Team> Teams { get; set; }
        public DbSet<Schedule.Model.ScheduleEvent> ScheduleEvents { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TeamMember.Model.TeamMember>()
                .HasNoDiscriminator()
                .ToContainer(nameof(TeamMember.Model.TeamMember))
                .HasPartitionKey(p => p.Id);

            modelBuilder.Entity<TeamMember.Model.TeamMember>().CamelCasePropertyNames();

            modelBuilder.Entity<Team.Model.Team>()
                .HasNoDiscriminator()
                .ToContainer(nameof(Team.Model.Team))
                .HasPartitionKey(p => p.Id);

            modelBuilder.Entity<Team.Model.Team>().CamelCasePropertyNames();

            modelBuilder.Entity<Schedule.Model.ScheduleEvent>()
                .HasNoDiscriminator()
                .ToContainer(nameof(Schedule.Model.ScheduleEvent))
                .HasPartitionKey(p => p.Id);

            modelBuilder.Entity<Schedule.Model.ScheduleEvent>().CamelCasePropertyNames();
        }
    }

    public static class EntityTypeBuilderExtensions
    {
        public static void CamelCasePropertyNames<T>(this EntityTypeBuilder<T> entity)
            where T : class
        {
            foreach (var property in typeof(T).GetProperties())
            {
                entity.Property(property.Name)
                    .ToJsonProperty(char.ToLowerInvariant(property.Name[0]) + property.Name.Substring(1));
            }
        }
    }
}
