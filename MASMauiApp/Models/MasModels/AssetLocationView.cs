using System;

namespace AssetManagementApp.Models
{
    public class AssetLocationView
    {
        public int AssetId { get; set; }
        public int LocationId { get; set; }
        public DateTime? UpdateAt { get; set; }
        public string UpdateBy { get; set; }
        public string Remark { get; set; }
        public string LocationCode { get; set; }
        public string LocationNameEn { get; set; }
        public string LocationNameVn { get; set; }
        public string LocationNameCn { get; set; }
        public string DeptCode { get; set; }
        public string CompanyCode { get; set; }
        public string DeptNameEn { get; set; }
        public string DeptNameVn { get; set; }
        public string DeptNameCn { get; set; }
    }
}
