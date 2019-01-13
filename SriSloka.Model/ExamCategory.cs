using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SriSloka.Model
{
    public class ExamCategory
    {
        [Key]
        public int ExamCategoryId { get; set; }

        public string CategoryName { get; set; }

        public bool IsActive { get; set; }
    }
}
