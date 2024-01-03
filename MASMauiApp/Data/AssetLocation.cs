using SQLite;
using System;

namespace AssetManagementApp.Data
{
    public class AssetLocation
    {
        [PrimaryKey]
        public string AssetCode { get; set; }
        public int LocationId { get; set; }
        public DateTime UpdateAt { get; set; }
        public string UpdateBy { get; set; }
        public string SyncStatus { get; set; }
    }
}
