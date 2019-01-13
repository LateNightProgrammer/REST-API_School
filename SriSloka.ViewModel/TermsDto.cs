using System;

namespace SriSloka.ViewModel
{
    public class TermsDto
    {
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

