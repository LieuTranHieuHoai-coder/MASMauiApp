using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace AssetManagementApp.Models
{
    public partial class Roles
    {
        public int RoleId { get; set; }
        public string RoleNameEn { get; set; }
        public string RoleNameVn { get; set; }
        public string RoleNameCn { get; set; }
    }
}
