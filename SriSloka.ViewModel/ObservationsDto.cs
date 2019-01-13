using SriSloka.Model;

namespace SriSloka.ViewModel
{
    public class ObservationsDto: TrackableEntity
    {
        public int ObservationsId { get; set; }
        
        public int TeacherId { get; set; }

        public string Notes { get; set; }
        
        public int AcadamicHistoryId { get; set; }
    }
}
