namespace MASMauiApp.XamlPages;

public partial class ScanChangeLoction
{
	public ScanChangeLoction()
	{
		InitializeComponent();
	}
    public ScanChangeLoction(int locationid, string userid)
    {
        InitializeComponent();
    }
    private async Task<int> ChangLocation(int locid,string assetCode, string userid)
    {
        try
        {
            using (var client = new HttpClient { BaseAddress = new Uri(Global.MasApiUrl.amsUrl) })
            {
                var api = "/api/SetLocation?locid=" + locid + "&qr="+ assetCode + "&user="+ userid;
                var response = await client.GetAsync(api);
                if (response.IsSuccessStatusCode)
                {
                    return 1;
                }
                else { return 0; }
            }
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
        var result = await ChangLocation(Global.ObjClass.locationid,e.Results[0].Value, Shared.SevicesBase.LOGGEDUSER.UserName);
        if (result == 0)
        {
            barcodeReader.IsDetecting = true;
        }
        else
        {
            barcodeReader.IsDetecting = false;
            Close(result);
        }
    }
}