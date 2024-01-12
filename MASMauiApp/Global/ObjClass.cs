using MASMauiApp.Models;

namespace MASMauiApp.Global
{
    public class ObjClass
    {
        public static AssetInfo AssetInfo { get; set; }
        public static string AssetCode { get; set; }
        public static string userid { get; set; }
        public static int locationid { get; set; }
        public static List<MASHistoryRepair> HistoryRepairList {  get; set; }
    }
}
