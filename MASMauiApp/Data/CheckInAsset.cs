using System;
using SQLite;

namespace AssetManagementApp.Data
{
    public class CheckInAsset
    {
        [PrimaryKey, AutoIncrement]
        public int CIEId { get; set; }
        public string CheckInNo { get; set; }
        public string AssetCode { get; set; }
        public DateTime? CheckInDate { get; set; }
        public string SyncStatus { get; set; }
    }
}
