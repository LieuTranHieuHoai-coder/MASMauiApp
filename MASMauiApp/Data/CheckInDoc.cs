using SQLite;
using System;


namespace AssetManagementApp.Data
{
    public class CheckInDoc
    {
        [PrimaryKey]
        public string CheckInNo { get; set; }
        public string DocStatus { get; set; }
        public string Remark { get; set; }
        public DateTime? CreateDate { get; set; }
        public string CreateBy { get; set; }
        public DateTime? ModifyDate { get; set; }
        public string ModifyBy { get; set; }        
    }
}
