using MASMauiApp.Business;
using MASMauiApp.Global;
using MASMauiApp.Models;
using Newtonsoft.Json;
using System.Text;

namespace MASMauiApp.XamlPages;

public partial class ScanConfirm
{
    HistoryRepairBusiness HistoryRepairBusiness = new HistoryRepairBusiness();
    List<MASHistoryRepair> _repair = new List<MASHistoryRepair>();
    public ScanConfirm()
	{
		InitializeComponent();
	}
    public ScanConfirm(List<MASHistoryRepair> repairs)
    {
        InitializeComponent();
        _repair = repairs;
    }
    private async void barcodeReader_BarcodesDetected(object sender, ZXing.Net.Maui.BarcodeDetectionEventArgs e)
    {
        
        barcodeReader.IsDetecting = false;
        var result = await HistoryRepairBusiness.ConfirmUser(e.Results[0].Value.ToString());
       
        if (result == null)
        {
            //barcodeReader.IsDetecting = true;
            Close("wronguser");
        }
        else
        {
            //barcodeReader.IsDetecting = false;
            //for (int i = 0; i < _repair.Count; i++)
            //{
            //    _repair[i].ConfirmDate = DateTime.Now;
            //    _repair[i].ConfirmUser = result.UserName;
            //    await HistoryRepairBusiness.Update(_repair[i]);
            //}
            foreach (var pair in _repair)
            {
                pair.ConfirmDate = DateTime.Now;
                pair.ConfirmUser = result.UserName;
                var a = await HistoryRepairBusiness.Update(pair);
                if (a <= 0)
                {

                    Close();
                }
            }
            Close("success");
        }
    }
}