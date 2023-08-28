using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using Data.TeamMember.Model;
using Data.TeamMember.Repository;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

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

        [Function("GetTeamMembers")]
        public async Task<HttpResponseData> GetList([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "teammembers")] HttpRequestData req)
        {
            var response = req.CreateResponse(HttpStatusCode.OK);
            var members = await _teamMemberRepository.GetTeamMembers();
            await response.WriteAsJsonAsync(members);

            return response;
        }

        [Function("DeleteTeamMember")]
        public async Task<HttpResponseData> Delete([HttpTrigger(AuthorizationLevel.Anonymous, "delete", Route = "teammember/{id}")] HttpRequestData req,
            string id)
        {
            await _teamMemberRepository.DeleteTeamMember(id);
            var response = req.CreateResponse(HttpStatusCode.OK);

            return response;
        }

        [Function("AddTeamMember")]
        public async Task<HttpResponseData> Add([HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "teammember")] HttpRequestData req)
        {
            var bodyStream = new StreamReader(req.Body);
            var teamMember = JsonConvert.DeserializeObject<TeamMember>(bodyStream.ReadToEnd());
            teamMember.Id = Guid.NewGuid().ToString();
            await _teamMemberRepository.AddTeamMember(teamMember);
            var response = req.CreateResponse(HttpStatusCode.OK);

            return response;
        }

    }
}
