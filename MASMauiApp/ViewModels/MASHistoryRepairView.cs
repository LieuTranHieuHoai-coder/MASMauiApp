using MASMauiApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MASMauiApp.ViewModels
{
    public class MASHistoryRepairView : MASHistoryRepair
    {
        public string User {  get; set; }
        public string DefectName { get; set; }
        public string AssetNameVn { get; set; }
        public string AssetNameCn { get; set; }
        public string AssetNameEn { get; set; }
    }
}
