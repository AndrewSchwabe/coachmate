using System.ComponentModel.DataAnnotations;

namespace Client.Models.Schedule
{
    public class AddScheduleEventModel
    {
        public string Id => Guid.NewGuid().ToString();

        [Required]
        public string Title { get; set; }

        [Required]
        public DateTime? Start { get; set; } = DateTime.Now;
        [Required]
        public TimeSpan? StartTime { get; set; }
        public TimeSpan? End { get; set; }
    }
}
