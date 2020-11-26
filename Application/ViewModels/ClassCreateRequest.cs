using System;

namespace Application.ViewModels
{
    public class ClassCreateRequest
    {
        public int ClassId { get; set; }
        public string name { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public decimal price { get; set; }
    }
}