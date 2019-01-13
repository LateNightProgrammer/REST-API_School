using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SriSloka.SharedKernel;

namespace SriSloka.Model
{
    public class Attendance :IStateObject
    {
        [Key]
        public int AttendanceId { get; set; }

        public DateTime Date { get; set; }

        [ForeignKey("Student")]
        public int StudentId { get; set; }

        [ForeignKey("Staff")]
        public int StaffId { get; set; }

        public bool IsPresent { get; set; }

        public string ReasonForAbsence { get; set; }

        [NotMapped]
        public ObjectState ObjectState { get; set; }

        public Attendance(int studentId)
        {
            StudentId = studentId;
        }

        public Attendance() { }
    }
}
