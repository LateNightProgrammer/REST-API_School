using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SriSloka.ViewModel
{
    public class HomeworkSubmissionDto
    {
        public int HomeworkId { get; set; }

        public int StudentId { get; set; }

        public DateTime SubmissionDate { get; set; }

        public Grade Grade { get; set; }
    }
}
