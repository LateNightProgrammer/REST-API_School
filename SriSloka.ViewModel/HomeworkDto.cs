using System;

namespace SriSloka.ViewModel
{
    public class HomeworkDto
    {
        public int HomeworkId { get; set; }

        public string Description { get; set; }
     
        public int TeacherId { get; set; }
        
        public int StandardId { get; set; }
        
        public int StudentId { get; set; }

        public DateTime Date { get; set; }
        
        public int SubjectsId { get; set; }
    }
}
