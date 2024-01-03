using System;
using System.Collections.Generic;

namespace AssetManagementApp.Models
{
    public class CheckInDocs
    {
        public int ChId { get; set; }
        public string CheckInNo { get; set; }
        public string Remark { get; set; }
        public string DocStatus { get; set; }
        public DateTime? CreateDate { get; set; }
        public string CreateBy { get; set; }
        public DateTime? ModifyDate { get; set; }
        public string ModifyBy { get; set; }

        public virtual ICollection<CheckInAssets> CheckInAssets { get; set; }
    }
}
