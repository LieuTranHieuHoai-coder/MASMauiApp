using MASMauiApp.Business;
using MASMauiApp.Global;
using MASMauiApp.Models;
using Microsoft.AspNetCore.Components.Routing;
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
            Close("wronguser");
        }
        else
        {
            List<MASHistoryRepair> listrepair = new List<MASHistoryRepair>();
            listrepair = await HistoryRepairBusiness.GetMASHistoryRepairAsset(Global.ObjClass.AssetCode);
            var temp = listrepair.Where(x => x.DefectId == 0).ToList();
            var listFirstScan = temp.Where(x => x.RepairStatus == true).ToList();
            if (listFirstScan.Count > 0)
            {
                for (int i = 0; i < listFirstScan.Count; i++)
                {
                    if (listFirstScan[i].RepairStatus == true)
                    {
                        await HistoryRepairBusiness.Update(new MASHistoryRepair
                        {
                            ConfirmUser = result.UserName,
                            Id = listFirstScan[i].Id,
                            RepairStatus = false,
                            ConfirmDate = DateTime.Now,
                            BrokenStatus = false,
                            WorkStatus = true,
                    });
                    }
                }
                
            }

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