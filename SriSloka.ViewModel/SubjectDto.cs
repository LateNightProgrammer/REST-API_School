using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using SriSloka.Model;

namespace SriSloka.ViewModel
{
    public class SubjectDto
    {
        public int SubjectId { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 3)]
        public string SubjectName { get; set; }

        public ICollection<Traits> Traits { get; set; }
    }
}
