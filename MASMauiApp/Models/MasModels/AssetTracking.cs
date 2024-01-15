using System;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace AssetManagementApp.Models
{
    public partial class AssetTracking
    {
        public int TrackId { get; set; }
        public int? AssetId { get; set; }
        public int? LocationId { get; set; }
        public DateTime? TrackDate { get; set; }
        public string TrackBy { get; set; }
        public string Remark { get; set; }
    }
}
