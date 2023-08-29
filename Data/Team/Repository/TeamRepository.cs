using Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Data.Team.Repository
{
    public class TeamRepository : ITeamRepository
    {
        private readonly DataContext _dataContext;
        public TeamRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task AddTeam(Model.Team team)
        {
            await _dataContext.Teams.AddAsync(team);
            await _dataContext.SaveChangesAsync();
        }

        public async Task DeleteTeam(string id)
        {
            var team = await _dataContext.Teams.SingleOrDefaultAsync(t => t.Id == id).ConfigureAwait(false);
            if (team != null)
            {
                _dataContext.Teams.Remove(team);
                await _dataContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Model.Team>> GetTeams()
        {
            return await _dataContext.Teams.ToListAsync().ConfigureAwait(false);
        }
    }
}
