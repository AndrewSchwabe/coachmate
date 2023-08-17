using System;
using System.Linq;
using System.Net;
using BlazorApp.Shared;
using BlazorApp.Shared.TeamMember.Model;
using BlazorApp.Shared.TeamMember.Repository;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace ApiIsolated
{
    public class HttpTrigger
    {
        private readonly ILogger _logger;

        public HttpTrigger(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<HttpTrigger>();
        }

        [Function("TeamMembers")]
        public HttpResponseData Run([HttpTrigger(AuthorizationLevel.Anonymous, "get")] HttpRequestData req)
        {
            var repo = new TeamMemberRepository();
            var response = req.CreateResponse(HttpStatusCode.OK);
            response.WriteAsJsonAsync(repo.GetTeamMembers());

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
