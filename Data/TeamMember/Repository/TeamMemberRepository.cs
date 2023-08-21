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

        public async Task<IEnumerable<Model.TeamMember>> GetTeamMembers()
        {
            return await _dataContext.TeamMembers.ToListAsync().ConfigureAwait(false);
        }
    }
}
