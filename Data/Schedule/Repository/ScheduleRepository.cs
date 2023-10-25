using Data.Context;
using Data.Schedule.Model;
using Microsoft.EntityFrameworkCore;

namespace Data.Schedule.Repository
{
    public class ScheduleRepository : IScheduleRepository
    {
        private readonly DataContext _dataContext;

        public ScheduleRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task AddEvent(ScheduleEvent scheduleEvent)
        {
            await _dataContext.AddAsync(scheduleEvent);
            await _dataContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<ScheduleEvent>> GetSchedule()
        {
            return await _dataContext.ScheduleEvents.ToListAsync().ConfigureAwait(false);
        }
    }
}
