using System;
using System.Collections.Generic;
using System.Text;

namespace MASMauiApp.Models
{
    public class AssetInfo
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
        //location fields
        public string LocationCode { get; set; }
        public string LocationNameEn { get; set; }
        public string LocationNameVn { get; set; }
        public string LocationNameCn { get; set; }
        public string DeptCode { get; set; }
        public string DeptNameEn { get; set; }
        public string DeptNameVn { get; set; }
        public string DeptNameCn { get; set; }

        public List<AssetTrackingView> AssetTrackings { get; set; }
    }
}
