using System;
namespace Domain.Models
{
        public class StudentInClass
    {
        public int classId { get; set; }
        public Student student { get; set; }
        public int studentId { get; set; }
        public Class classs { get; set; }
    }
}