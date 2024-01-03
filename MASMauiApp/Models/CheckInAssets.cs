using System;

namespace AssetManagementApp.Models
{
    public class CheckInAssets
    {
        public int ChDid { get; set; }
        public int? ChId { get; set; }
        public string AssetCode { get; set; }
        public DateTime? CheckInDate { get; set; }

    }
}
