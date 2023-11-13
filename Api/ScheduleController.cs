using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using System.Threading.Tasks;
using System.Net;
using Data.Team.Repository;
using Newtonsoft.Json;
using System.IO;
using Data.Team.Model;
using Data.Schedule.Repository;
using Data.Schedule.Model;
using System.Linq;

namespace Api
{
    public class ScheduleController
    {
        private readonly IScheduleRepository _scheduleRepository;

        public ScheduleController(IScheduleRepository scheduleRepository) 
        {
            _scheduleRepository = scheduleRepository;
        }

        [Function("GetSchedule")]
        public async Task<HttpResponseData> GetList([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "schedule")] HttpRequestData req)
        {
            var response = req.CreateResponse(HttpStatusCode.OK);
            var schedule = await _scheduleRepository.GetSchedule();
            await response.WriteAsJsonAsync(schedule.OrderBy(se => se.Start)).ConfigureAwait(false);
            return response;
        }

        [Function("AddEvent")]
        public async Task<HttpResponseData> Add([HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "schedule")] HttpRequestData req)
        {
            var bodyStream = new StreamReader(req.Body);
            var scheduleEvent = JsonConvert.DeserializeObject<ScheduleEvent>(bodyStream.ReadToEnd());
            await _scheduleRepository.AddEvent(scheduleEvent);
            var response = req.CreateResponse(HttpStatusCode.OK);

            return response;
        }

    }
}
