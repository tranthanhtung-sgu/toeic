using System;
using Microsoft.AspNetCore.Http;

namespace Application.ViewModels.Lessons
{
    public class CreateLessonRequest
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public int teacherId { get; set; }
        public string TeacherName { get; set; }
        public int levelId { get; set; }
        public string Level { get; set; }
        public int categoryId { get; set; }
        public string CategoryName { get; set; }
        public IFormFile ThumbnailsImage { get; set; }
    }
}
