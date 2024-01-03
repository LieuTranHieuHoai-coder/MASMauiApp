using System;

namespace MASMauiApp.Models
{
    public class MASMachineDefects
    {
        public int Id { get; set; }
        public string DefectNameVN { get; set; }
        public string DefectNameEN { get; set; }
        public string DefectNameCN { get; set; }
        public string DefectNameTW { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
    }
}
