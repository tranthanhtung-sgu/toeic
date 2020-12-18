using System;
using System.Collections.Generic;
using Application.ViewModels.Common;

namespace Application.ViewModels.User
{
    public class RoleAssignRequest
    {
        public int Id { get; set; }
        public List<SelectItem> Roles { get; set; } = new List<SelectItem>();
    }
}
