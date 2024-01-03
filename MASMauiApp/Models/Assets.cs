using System;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace AssetManagementApp.Models
{
    public partial class Assets
    {
        public int AssetId { get; set; }
        public string AssetCode { get; set; }
        public string AssetNameEn { get; set; }
        public string AssetNameVn { get; set; }
        public string AssetNameCn { get; set; }
        public string CompanyCode { get; set; }
        public string CatCode { get; set; }
        public string ItemCode { get; set; }
        public string BrandCode { get; set; }
        public string ModelCode { get; set; }
        public string UnitCode { get; set; }
        public string TagString { get; set; }
        public string SerialNumber { get; set; }
        public string ImageUrl { get; set; }
        public string StatusCode { get; set; }
        public string Remark { get; set; }
        public DateTime? CreateDate { get; set; }
        public string CreateBy { get; set; }
        public DateTime? ModifyDate { get; set; }
        public string ModifyBy { get; set; }
        public string PurOrderNo { get; set; }
        public string PurRcvNo { get; set; }
        public DateTime? RcvDate { get; set; }
    }
}
