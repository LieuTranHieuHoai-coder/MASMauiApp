using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace AssetManagementApp.Models
{
    public partial class Items
    {
        public int ItemId { get; set; }
        public string ItemCode { get; set; }
        public string CatCode { get; set; }
        public string ItemNameEn { get; set; }
        public string ItemNameVn { get; set; }
        public string ItemNameCn { get; set; }
        public string Remark { get; set; }
        public DateTime? CreateDate { get; set; }
        public string CreateBy { get; set; }
        public DateTime? ModifyDate { get; set; }
        public string ModifyBy { get; set; }
    }
}
