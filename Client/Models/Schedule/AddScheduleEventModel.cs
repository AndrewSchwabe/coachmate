using System.ComponentModel.DataAnnotations;

namespace Client.Models.Schedule
{
    public class AddScheduleEventModel
    {
        public string Id => Guid.NewGuid().ToString();

        [Required]
        public string Title { get; set; }

        [Required]
        public DateTime? Start { get; set; } = DateTime.Today;

        [Required]
        public TimeSpan? StartTime { get; set; } = DateTime.Now.TimeOfDay;
        
        [Required]
        public DateTime? End { get; set; } = DateTime.Today;

        [Required]
        public TimeSpan? EndTime { get; set; } = DateTime.Now.TimeOfDay.Add(TimeSpan.FromHours(1));
    }
}
