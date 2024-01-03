using SQLite;
using System;

namespace AssetManagementApp.Data
{
    public class Location
    {
        [PrimaryKey]
        public int LocationId { get; set; }
        public int ParentId { get; set; }
        public int CompanyId { get; set; }
        public int DeptId { get; set; }
        public string LocationCode { get; set; }
        public string LocationNameEn { get; set; }
        public string LocationNameVn { get; set; }
        public string LocationNameCn { get; set; }
        public string Remark { get; set; }
        public DateTime? CreateDate { get; set; }
        public string CreateBy { get; set; }
        public DateTime? ModifyDate { get; set; }
        public string ModifyBy { get; set; }
    }
}
