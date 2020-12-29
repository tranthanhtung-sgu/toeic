using System;
using System.Collections.Generic;
using Application.ViewModels.Common;

namespace Application.ViewModels.Category
{
    public class CategoryVm
    {
        public int Id { get; set; }
        public string name { get; set; }
        public List<SelectItem> SelectItems { get; set; } = new List<SelectItem>();

    }
}
