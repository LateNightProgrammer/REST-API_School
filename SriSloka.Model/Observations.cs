using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SriSloka.Model
{
    public class Observations: TrackableEntity
    {
        [Key]
        public int ObservationsId { get; set; }

        [ForeignKey("Teacher")]
        public int TeacherId { get; set; }

        public string Notes { get; set; }

        [ForeignKey("AcadamicHistory")]
        public int AcadamicHistoryId { get; set; }
    }
}
