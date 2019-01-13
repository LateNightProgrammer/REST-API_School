using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SriSloka.Model
{
    public class Schedule
    {
        [Key]
        public int  ScheduleId { get; set; }

        public string EventName { get; set; }

        public DateTime From { get; set; }

        public DateTime To { get; set; }

        public bool IsAllDayEvent { get; set; }

        [ForeignKey("Teacher")]
        public int TeacherId { get; set; }

        public bool IsDelete { get; set; }
    }
}
