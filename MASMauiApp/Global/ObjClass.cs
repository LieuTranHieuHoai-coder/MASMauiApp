using MASMauiApp.Models;
using MASMauiApp.Models.QmsModels;
using QMS.Models.PermitModels;

namespace MASMauiApp.Global
{
    public class ObjClass
    {
        public static AssetInfo AssetInfo { get; set; }
        public static string AssetCode { get; set; }
        public static string userid { get; set; }
        public static xUser LoggedUser { get; set; }
        public static List<AdminGroupPerm> Permisions { get; set; }
        public static string WorkingSite { get; set; }
        public static string WorkingFactory { get; set; }
        public static string WorkingLine { get; set; }
    }
}
