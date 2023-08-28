namespace Data.TeamMember.Repository
{
    public interface ITeamMemberRepository
    {
        Task<IEnumerable<Model.TeamMember>> GetTeamMembers();
        Task AddTeamMember(Model.TeamMember teamMember);
        Task DeleteTeamMember(string id);
    }
}