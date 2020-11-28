using System;
using Domain.Models;

namespace Application.ViewModels.Class
{
    public class ClassUpdateModel
    {
        public string name { get; set; }
        public decimal price { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        
    }
}