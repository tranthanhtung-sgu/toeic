using System.Collections.Generic;

namespace Domain.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string name { get; set; }
        public List<Course> courses { get; set; }
    }
}