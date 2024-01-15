using System;

namespace MASMauiApp.Models
{
    public class MASRepairMethods
    {
        public int Id { get; set; }
        public string MethodNameVN { get; set; }
        public string MethodNameEN { get; set; }
        public string MethodNameCN { get; set; }
        public string MethodNameTW { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
    }
}
