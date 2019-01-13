using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SriSloka.Model
{
    public class Subject
    {
        [Key]
        public int SubjectId { get; set; }

        public string SubjectName { get; set; }

        public virtual ICollection<Traits> Traits { get; set; }
    }
}
