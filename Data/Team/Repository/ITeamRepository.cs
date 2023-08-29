namespace Data.Team.Repository
{
    public interface ITeamRepository
    {
        Task<IEnumerable<Model.Team>> GetTeams();
        Task AddTeam(Model.Team team);
        Task DeleteTeam(string id);
    }
}