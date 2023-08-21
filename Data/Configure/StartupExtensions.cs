using Data.Context;
using Data.TeamMember.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Data.Configure
{
    public static class StartupExtensions
    {
        public static void ConfigureDataServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddDbContextFactory<DataContext>((IServiceProvider provider, DbContextOptionsBuilder builder) =>
            {
                builder.UseCosmos(
                    "https://localhost:8081",
                    "C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==",
                    "CoachMate");
            });

            serviceCollection.AddTransient<ITeamMemberRepository, TeamMemberRepository>();
        }
    }
}
