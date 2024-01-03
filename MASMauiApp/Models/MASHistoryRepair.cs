using System;

namespace MASMauiApp.Models
{
    public class MASHistoryRepair
    {
        public int Id {  get; set; }
        public string AssetCode { get; set; }
        public int DefectId { get; set; }
        public int MethodId { get; set; }
        public bool? RepairStatus { get; set; }
        public bool? BrokenStatus { get; set; }
        public DateTime? BeginWork { get; set; }
        public DateTime? EndWork { get; set; }
        public bool? WorkStatus { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public string Line {  get; set; }
        public string DeptCode { get; set; }
        public string OtherDefect { get; set; }
        public string Method { get; set; }
        public string OtherMethod {  get; set; }
    }
}
