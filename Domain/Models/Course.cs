using System.Collections.Generic;

namespace Domain.Models
{
    public class Course
    {
        public int Id { get; set; }
        public int lessons { get; set; }
        public string description { get; set; }
        public string term { get; set; }
        public Level level { get; set; }
        public Category category { get; set; }
        public int levelId { get; set; }
        public int categoryId { get; set; }
        public List<Class> Classes { get; set; }
    }
}