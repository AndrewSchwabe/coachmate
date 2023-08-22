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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TeamMember.Model.TeamMember>()
                .HasNoDiscriminator()
                .ToContainer(nameof(TeamMember.Model.TeamMember))
                .HasPartitionKey(p => p.Id);

            modelBuilder.Entity<TeamMember.Model.TeamMember>().CamelCasePropertyNames();
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
