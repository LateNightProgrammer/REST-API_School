using System;
using SriSloka.Model;

namespace SriSloka.ViewModel
{
    public class TransportDto
    {
        public int TransportId { get; set; }

        public int StudentId { get; set; }

        public Decimal DistanceInKms { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
     
        public virtual Student Student { get; set; }
    }
}
