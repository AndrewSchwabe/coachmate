using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Data.Team.Repository;
using Data.TeamMember.Model;
using Newtonsoft.Json;
using System.IO;
using Data.Team.Model;

namespace Api
{
    public class TeamController
    {
        private readonly ITeamRepository _teamRepository;

        public TeamController(ITeamRepository teamRepository) 
        {
            _teamRepository = teamRepository;
        }

        [Function("GetTeams")]
        public async Task<HttpResponseData> GetList([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "teams")] HttpRequestData req)
        {
            var response = req.CreateResponse(HttpStatusCode.OK);
            var teams = await _teamRepository.GetTeams();
            await response.WriteAsJsonAsync(teams).ConfigureAwait(false);
            return response;
        }

        [Function("DeleteTeam")]
        public async Task<HttpResponseData> Delete([HttpTrigger(AuthorizationLevel.Anonymous, "delete", Route = "team/{id}")] HttpRequestData req,
           string id)
        {
            await _teamRepository.DeleteTeam(id);
            var response = req.CreateResponse(HttpStatusCode.OK);

            return response;
        }

        [Function("AddTeam")]
        public async Task<HttpResponseData> Add([HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "team")] HttpRequestData req)
        {
            var bodyStream = new StreamReader(req.Body);
            var team = JsonConvert.DeserializeObject<Team>(bodyStream.ReadToEnd());
            await _teamRepository.AddTeam(team);
            var response = req.CreateResponse(HttpStatusCode.OK);

            return response;
        }
    }
}
