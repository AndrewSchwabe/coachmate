using Microsoft.EntityFrameworkCore;

namespace Data.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options): base(options) 
        {

        }

        public DbSet<TeamMember.Model.TeamMember> TeamMembers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TeamMember.Model.TeamMember>()
                .HasNoDiscriminator()
                .ToContainer(nameof(TeamMember.Model.TeamMember))
                .HasPartitionKey(p => p.Id);
        }
    }
}
