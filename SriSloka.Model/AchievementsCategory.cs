using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SriSloka.Model
{
    public class AchievementsCategory
    {
        [Key]
        public int AchievementsCategoryId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}
