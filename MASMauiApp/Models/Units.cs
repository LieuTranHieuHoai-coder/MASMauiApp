using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace AssetManagementApp.Models
{
    public partial class Units
    {
        public string UnitCode { get; set; }
        public string UnitName { get; set; }
        public string UnitType { get; set; }
        public string BaseUnit { get; set; }
        public decimal? Factor { get; set; }
        public string DecscriptionEn { get; set; }
        public string DecscriptionCn { get; set; }
        public string DecscriptionVn { get; set; }
        public string Remark { get; set; }
        public DateTime? CreateDate { get; set; }
        public string CreateBy { get; set; }
        public DateTime? ModifyDate { get; set; }
        public string ModifyBy { get; set; }
    }
}
