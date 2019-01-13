using System.ComponentModel.DataAnnotations;

namespace SriSloka.ViewModel
{
    public class TraitsDto
    {
        public int TraitsId { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }

        [StringLength(100)]
        public string Description { get; set; }

        public bool IsDelete { get; set; }
    }
}
