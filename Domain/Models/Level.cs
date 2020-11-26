using System.Collections.Generic;

namespace Domain.Models
{
    public class Level
    {
        public int Id { get; set; }
        public char sign { get; set; }
        public string name { get; set; }
        public List<Course> courses { get; set; }
    }
}