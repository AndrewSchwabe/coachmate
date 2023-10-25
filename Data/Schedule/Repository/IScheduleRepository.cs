using Data.Schedule.Model;

namespace Data.Schedule.Repository
{
    public interface IScheduleRepository
    {
        Task AddEvent(ScheduleEvent scheduleEvent);
        Task<IEnumerable<ScheduleEvent>> GetSchedule();
    }
}