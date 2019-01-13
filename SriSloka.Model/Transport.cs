using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SriSloka.SharedKernel;

namespace SriSloka.Model
{
    public class Transport : IStateObject
    {
        [Key]
        public int TransportId { get; set; }

        [ForeignKey("Student")]
        public int StudentId { get; set; }

        public Decimal DistanceInKms { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        [ForeignKey("StudentId")]
        public virtual Student Student { get; set; }

        [NotMapped]
        public ObjectState ObjectState { get; set; }

        public Transport(int studentId)
        {
            StudentId = studentId;
        }

      /// <summary>
      /// Entity Framework requirement.
      /// </summary>
      public Transport()
      {
      }
    }
}
