using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SriSloka.Model
{
    public class Achievements
    {
        [Key]
        public int AchievementsId { get; set; }

        public string Description { get; set; }

        public DateTime Date { get; set; }

        [ForeignKey("AchievementsCategory")]
        public int AchievementsCategoryId { get; set; }

        [ForeignKey("AcadamicHistory")]
        public int AcadamicHistoryId { get; set; }

       // public virtual AchievementsCategory Category { get; set; }

        public bool IsDelete { get; set; }
    }
}
