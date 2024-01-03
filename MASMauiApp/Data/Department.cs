using SQLite;
using System;

namespace AssetManagementApp.Data
{
    public class Department
    {
        [PrimaryKey]
        public int DeptId { get; set; }
        public string DeptCode { get; set; }
        public string CompanyCode { get; set; }
        public string DeptNameEn { get; set; }
        public string DeptNameVn { get; set; }
        public string DeptNameCn { get; set; }
        public string Remark { get; set; }
        public DateTime? CreateDate { get; set; }
        public string CreateBy { get; set; }
        public DateTime? ModifyDate { get; set; }
        public string ModifyBy { get; set; }
    }
}
