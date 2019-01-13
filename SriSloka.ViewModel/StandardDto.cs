using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using SriSloka.Model;

namespace SriSloka.ViewModel
{
    public class StandardDto
    {
        public StandardDto()
        {
        }
        
        public int StandardId { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 3)]
        public string Name { get; set; }

        [StringLength(150)]
        public string Description { get; set; }

        public bool IsDelete { get; set; }
    }
}
