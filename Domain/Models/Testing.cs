using System;
namespace Domain.Models
{
    public class Testing
    {
        public int Id { get; set; }
        public Level Level { get; set; }
        public int LevelId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public Teacher Teacher { get; set; }
        public int TeacherId { get; set; }
        public Category Category { get; set; }
        public int categoryId { get; set; }
    }
}
