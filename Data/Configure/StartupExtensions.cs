﻿using Data.Context;
using Data.Schedule.Repository;
using Data.Team.Repository;
using Data.TeamMember.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Data.Configure
{
    public static class StartupExtensions
    {
        public static void ConfigureDataServices(this IServiceCollection serviceCollection, IConfiguration config)
        {
            serviceCollection.AddDbContextFactory<DataContext>((IServiceProvider provider, DbContextOptionsBuilder builder) =>
            {
                builder.UseCosmos(
                    $"{config["CosmosUrl"]}",
                    $"{config["CosmosKey"]}",
                    $"{config["DatabaseId"]}");
            });

            serviceCollection.AddTransient<ITeamRepository, TeamRepository>();
            serviceCollection.AddTransient<ITeamMemberRepository, TeamMemberRepository>();
            serviceCollection.AddTransient<IScheduleRepository, ScheduleRepository>();
        }
    }
}
