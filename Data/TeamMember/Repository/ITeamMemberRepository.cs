namespace Data.TeamMember.Repository
{
    public interface ITeamMemberRepository
    {
        Task<IEnumerable<Model.TeamMember>> GetTeamMembers();
    }
}