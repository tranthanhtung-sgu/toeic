using System.Collections.Generic;

namespace Domain.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string name { get; set; }
        public List<Course> courses { get; set; }
        public List<GuideLine> guideLines { get; set; }
        public List<Testing> testings { get; set; }
    }
}