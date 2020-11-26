using System;

namespace Domain.Models
{
    public class Payment
    {
        public int Id { get; set; }
        public DateTime paymentDate { get; set; }
        public decimal amount { get; set; }
        public int paymentMethod { get; set; }
        public int status { get; set; }
        public Student Student { get; set; }
        public int studentId { get; set; }
        public Class Class { get; set; }
        public int classId { get; set; }

    }
}