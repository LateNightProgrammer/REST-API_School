using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Cryptography;
using System.Text;

namespace SriSloka.Model
{
    public class Photos
    {
        [Key]
        public int PhotosId { get; set; }

        public Byte[] Photo { get; set; }

        [ForeignKey("Student")]
        public int? StudentId { get; set; }

        [ForeignKey("Staff")]
        public int? StaffId { get; set; }
    }
}
