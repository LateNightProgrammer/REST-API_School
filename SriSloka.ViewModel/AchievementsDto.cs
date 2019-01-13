using System;
using SriSloka.Model;

namespace SriSloka.ViewModel
{
    public class AchievementsDto
    {
        public int AchievementsId { get; set; }

        public string Description { get; set; }

        public DateTime Date { get; set; }
        
        public int AchievementsCategoryId { get; set; }
        
        public int AcadamicHistoryId { get; set; }

        public AchievementsCategory Category { get; set; }

        public bool IsDelete { get; set; }
    }
}
