using System.Net;
using System.Threading.Tasks;
using Data.TeamMember.Repository;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace Api
{
    public class TeamMemberController
    {
        private readonly ITeamMemberRepository _teamMemberRepository;
        private readonly ILogger _logger;

        public TeamMemberController(
            ITeamMemberRepository teamMemberRepository,
            ILoggerFactory loggerFactory)
        {
            _teamMemberRepository = teamMemberRepository;
            _logger = loggerFactory.CreateLogger<TeamMemberController>();
        }

        [Function("TeamMembers")]
        public async Task<HttpResponseData> Run([HttpTrigger(AuthorizationLevel.Anonymous, "get")] HttpRequestData req)
        {
            var response = req.CreateResponse(HttpStatusCode.OK);
            var members = await _teamMemberRepository.GetTeamMembers();
            await response.WriteAsJsonAsync(members);

            return response;
        }

        private string GetSummary(int temp)
        {
            var summary = "Mild";

            if (temp >= 32)
            {
                summary = "Hot";
            }
            else if (temp <= 16 && temp > 0)
            {
                summary = "Cold";
            }
            else if (temp <= 0)
            {
                summary = "Freezing";
            }

            return summary;
        }
    }
}
