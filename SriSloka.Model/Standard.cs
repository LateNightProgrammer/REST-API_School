using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SriSloka.Model
{
    public class Standard
    {
        public Standard(){}

        [Key]
        public int StandardId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public bool IsDelete { get; set; }

    }
}
