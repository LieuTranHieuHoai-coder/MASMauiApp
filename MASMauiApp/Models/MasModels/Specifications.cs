using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace AssetManagementApp.Models
{
    public partial class Specifications
    {
        public int SpecsId { get; set; }
        public string AssetCode { get; set; }
        public string Cpu { get; set; }
        public string Memory { get; set; }
        public string Hdd { get; set; }
        public string Vga { get; set; }
        public string Wireless { get; set; }
        public string Os { get; set; }
        public string Baterry { get; set; }
        public string PowerAdaptor { get; set; }
        public string Remark { get; set; }
    }
}
