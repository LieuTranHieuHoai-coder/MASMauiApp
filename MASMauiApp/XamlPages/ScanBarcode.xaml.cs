using MASMauiApp.Models;

using Newtonsoft.Json;


namespace MASMauiApp.XamlPages;

public partial class ScanBarcode
{
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
        if (result == null)
        {
            barcodeReader.IsDetecting = true;
        }
        else
        {
            barcodeReader.IsDetecting = false;
            Global.ObjClass.AssetInfo = result;
            Global.ObjClass.AssetCode = e.Results[0].Value;
            Close();
        }
    }  
}