using System;

namespace SriSloka.ViewModel
{
    public class PhotosDto
    {
        public int PhotosId { get; set; }

        public Byte[] Photo { get; set; }
     
        public int? StudentId { get; set; }
        
        public int? StaffId { get; set; }
    }
}
