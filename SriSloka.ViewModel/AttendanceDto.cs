using System;

namespace SriSloka.ViewModel
{
    public class AttendanceDto
    {
        public int AttendanceId { get; set; }

        public DateTime Date { get; set; }
     
        public int StudentId { get; set; }
        
        public int StaffId { get; set; }

        public bool IsPresent { get; set; }

        public string ReasonForAbsence { get; set; }
    }
}
