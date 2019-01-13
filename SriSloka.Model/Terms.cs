using System;
using System.ComponentModel.DataAnnotations;

namespace SriSloka.Model
{
    public class Terms
    {
        [Key]
        public int TermsId { get; set; }

        public string Name { get; set; }

        public DateTime Start { get; set; }

        public DateTime End { get; set; }

        /// <summary>
        /// must be a year.
        /// </summary>
        public int AcadamicYear { get; set; }
    }
}

