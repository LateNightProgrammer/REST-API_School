using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SriSloka.Model
{
    public class TeacherClass
    {
        [Key]
        public int TeacherClassId { get; set; }

        [ForeignKey("Standard")]
        public int StandardId { get; set; }

        [ForeignKey("Teacher")]
        public int TeacherId { get; set; }

        [ForeignKey("Subject")]
        public int SubjectId { get; set; }
    }
}
