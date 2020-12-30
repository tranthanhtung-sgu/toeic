using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public class GuideLine
    {
        public int Id { get; set; }
        public Level level { get; set; }
        public int LevelId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public Teacher Teacher { get; set; }
        public int TeacherId { get; set; }
        public Category Category { get; set; }
        public int categoryId { get; set; }
        public List<GuideLineImage> images { get; set; }
    }
}
