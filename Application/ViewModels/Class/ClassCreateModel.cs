using System;

namespace Application.ViewModels.Class
{
    public class ClassCreateModel
    {
        public string name { get; set; }
        public decimal price { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
    }
}