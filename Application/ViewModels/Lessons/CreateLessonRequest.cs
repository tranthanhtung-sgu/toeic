using System;
namespace Application.ViewModels.Lessons
{
    public class CreateLessonRequest
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public int teacherId { get; set; }
        public string TeacherName { get; set; }
        public int levelId { get; set; }
        public string Level { get; set; }
        public int categoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
