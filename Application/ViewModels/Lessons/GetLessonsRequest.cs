using System;
using System.Collections.Generic;
using Application.ViewModels.Common;

namespace Application.ViewModels.Lessons
{
    public class GetLessonsRequest : PagingRequestBase
    {
        public string Keyword { get; set; }
        public int? levelId { get; set; }
        public int? teacherId { get; set; }
        public int? categoryId { get; set; }
    }
}
