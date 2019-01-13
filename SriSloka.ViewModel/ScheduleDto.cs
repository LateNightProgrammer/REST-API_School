using System;

namespace SriSloka.ViewModel
{
    public class ScheduleDto
    {
        public int  ScheduleId { get; set; }

        public string EventName { get; set; }

        public DateTime From { get; set; }

        public DateTime To { get; set; }

        public bool IsAllDayEvent { get; set; }
        
        public int TeacherId { get; set; }

        public bool IsDelete { get; set; }
    }
}
