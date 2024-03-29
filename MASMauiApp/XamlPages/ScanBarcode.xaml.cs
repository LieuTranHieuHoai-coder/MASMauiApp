using MASMauiApp.Business;
using MASMauiApp.Models;
using Newtonsoft.Json;


namespace MASMauiApp.XamlPages;

public partial class ScanBarcode
{
    public HistoryRepairBusiness repairBusiness = new HistoryRepairBusiness();
    public ScanBarcode()
	{
		InitializeComponent();
	}
    
    private async Task<AssetInfo> GetAssetInfo(string assetCode)
    {
        try
        {
            var assetInfo = new AssetInfo();
            using (var client = new HttpClient { BaseAddress = new Uri(Global.MasApiUrl.amsUrl) })
            {
                var api = "/api/getassetinfo/" + assetCode;
                var response = await client.GetAsync(api);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    if (!string.IsNullOrEmpty(content))
                    {
                        assetInfo = JsonConvert.DeserializeObject<AssetInfo>(content);
                        return assetInfo;
                    }
                }
                else { return null; }
            }
            return assetInfo;
        }
        catch (Exception)
        {

            throw;
        }
    }

    [Obsolete]
    private async void barcodeReader_BarcodesDetected(object sender, ZXing.Net.Maui.BarcodeDetectionEventArgs e)
    {
        barcodeReader.IsDetecting = false;
        AssetInfo result = await GetAssetInfo(e.Results[0].Value);
        MASHistoryRepair item = new MASHistoryRepair();
        if (result == null)
        {
            barcodeReader.IsDetecting = true;
        }
        else
        {
            List<MASHistoryRepair> listrepair = new List<MASHistoryRepair>();
            listrepair = await repairBusiness.GetMASHistoryRepairAsset(result.AssetCode);
            var temp = listrepair.Where(x => x.DefectId == 0).ToList();
            int range = temp.Where(x => x.RepairStatus == true).ToList().Count;
            if (range > 0)
            {
                Close("repair");
            }
            else
            {
                barcodeReader.IsDetecting = false;
                Global.ObjClass.AssetInfo = result;
                Global.ObjClass.AssetCode = e.Results[0].Value;
                item.AssetCode = e.Results[0].Value;
                item.DefectId = 0;
                item.MethodId = 0;
                item.RepairStatus = true;
                item.BrokenStatus = false;
                item.BeginWork = DateTime.Now;
                item.EndWork = null;
                item.WorkStatus = false;
                item.CreatedBy = MASMauiApp.Shared.SevicesBase.LOGGEDUSER.UserId.ToString();
                await repairBusiness.Insert(item);
                Close();
            }
            
        }
    }  
}