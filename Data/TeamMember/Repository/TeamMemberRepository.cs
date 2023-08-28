using Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Data.TeamMember.Repository
{
    public class TeamMemberRepository : ITeamMemberRepository
    {
        private readonly DataContext _dataContext;

        public TeamMemberRepository(DataContext dataContext)
        {
            _dataContext= dataContext;
        }

        public async Task AddTeamMember(Model.TeamMember teamMember)
        {
            await _dataContext.TeamMembers.AddAsync(teamMember);
            await _dataContext.SaveChangesAsync();  
        }

        public async Task DeleteTeamMember(string id)
        {
            var teamMember = await _dataContext.TeamMembers.SingleOrDefaultAsync(tm => tm.Id == id).ConfigureAwait(false);
            if (teamMember != null)
            {
                _dataContext.TeamMembers.Remove(teamMember);
                await _dataContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Model.TeamMember>> GetTeamMembers()
        {
            return await _dataContext.TeamMembers.ToListAsync().ConfigureAwait(false);
        }
    }
}
