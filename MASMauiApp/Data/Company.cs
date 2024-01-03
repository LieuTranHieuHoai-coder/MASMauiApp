using SQLite;
using System;

namespace AssetManagementApp.Data
{
    public class Company
    {
        [PrimaryKey]
        public int CompanyId { get; set; }
        public string CompanyCode { get; set; }
        public string CompanyNameEn { get; set; }
        public string CompanyNameVn { get; set; }
        public string CompanyNameCn { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Remark { get; set; }
        public DateTime? CreateDate { get; set; }
        public string CreateBy { get; set; }
        public DateTime? ModifyDate { get; set; }
        public string ModifyBy { get; set; }
    }
}
