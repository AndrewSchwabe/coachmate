﻿namespace Data.Schedule.Model
{
    public class ScheduleEvent
    {
        public string Id { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string Title { get; set; }
    }
}
