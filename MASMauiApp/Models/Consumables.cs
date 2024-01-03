using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace AssetManagementApp.Models
{
    public partial class Consumables
    {
        public int ConsId { get; set; }
        public string ConsCode { get; set; }
        public string ConsNameEn { get; set; }
        public string ConsNameVn { get; set; }
        public string ConsNameCn { get; set; }
        public string CompanyCode { get; set; }
        public int? CatId { get; set; }
        public string UnitCode { get; set; }
        public string BrandCode { get; set; }
        public string Model { get; set; }
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
