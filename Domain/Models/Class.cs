using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public class Class
    {
        public int Id { get; set; }
        public string name { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public decimal price { get; set; }
        public Teacher teacher { get; set; }
        public int teacherId { get; set; }
        public List<StudentInClass> studentInClasses { get; set; }
        public Course course { get; set; }
        public int courseId { get; set; }
        public List<Payment> payments { get; set; }
    }
}