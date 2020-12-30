using System;
namespace Domain.Models
{
    public class GuideLineImage
    {
        public int Id { get; set; }

        public int GuideLineId { get; set; }

        public string ImagePath { get; set; }

        public string Caption { get; set; }
        public bool IsDefault { get; set; }

        public DateTime DateCreated { get; set; }

        public int SortOrder { get; set; }

        public long FileSize { get; set; }

        public GuideLine GuideLine { get; set; }
    }
}
