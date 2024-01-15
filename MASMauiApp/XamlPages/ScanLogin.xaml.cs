using MASMauiApp.Models.QmsModels;
using Microsoft.Maui.Controls;
using Newtonsoft.Json;
using QMS.Models.PermitModels;
using CurrieTechnologies.Razor.SweetAlert2;
using CommunityToolkit.Maui.Core.Views;

namespace MASMauiApp.XamlPages;

public partial class ScanLogin
{
    public SweetAlertService Swal { get; set; }
    public string alert {  get; set; }
	public ScanLogin()
	{
		InitializeComponent();
	}

    private async void barcodeReader_BarcodesDetected(object sender, ZXing.Net.Maui.BarcodeDetectionEventArgs e)
    {
        try
        {
            barcodeReader.IsDetecting = false;
            string qrcode = e.Results[0].Value;

            if (CheckInternet())
            {
                using (var client = new HttpClient { BaseAddress = new Uri(Global.MasApiUrl.qmsApiUrl) })
                {
                    var api = $"/login/{qrcode}";
                    var response = await client.GetAsync(api);
                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        if (!string.IsNullOrEmpty(content))
                        {
                            var user = JsonConvert.DeserializeObject<xUser>(content);
                            if (user != null)
                            {
                                Global.ObjClass.LoggedUser = user;
                                await GetPermision(user.Id);
                                await SetWorkPlace(user.Uid);
                                alert = "success";
                                Close(alert);
                            }
                        }

                    }
                    else
                    {
                        //await Swal.FireAsync(
                        //    new SweetAlertOptions
                        //    {
                        //        Title = "Warrning",
                        //        Text = "Mã QR Code không hợp lệ",
                        //        Icon = SweetAlertIcon.Warning,
                        //        CancelButtonText = "Đóng"
                        //    }
                        //);
                        alert = "invalid";
                        
                        Close(alert);
                        
                    }
                }
            }
            else
            {
                alert = "internet";
                Close(2);
                //await Swal.FireAsync(
                //            new SweetAlertOptions
                //            {
                //                Title = "Error",
                //                Text = "Mất kết nối internet",
                //                Icon = SweetAlertIcon.Warning,
                //                CancelButtonText = "Đóng"
                //            }
                //        );
            }
        }
        catch (Exception ex)
        {
            Close(ex.Message.ToString());
            //await Swal.FireAsync(
            //                new SweetAlertOptions
            //                {
            //                    Title = "Error",
            //                    Text = ex.Message.ToString(),
            //                    Icon = SweetAlertIcon.Error,
            //                    CancelButtonText = "Đóng"
            //                }
            //            );
        }
    }

    private bool CheckInternet()
    {
        return Connectivity.NetworkAccess == NetworkAccess.Internet;
    }

    private async Task GetPermision(int id)
    {
        try
        {
            using (var client = new HttpClient { BaseAddress = new Uri(Global.MasApiUrl.qmsApiUrl) })
            {
                var api = $"/getperm/{id}";
                var response = await client.GetAsync(api);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    if (!string.IsNullOrEmpty(content))
                    {
                        var perms = JsonConvert.DeserializeObject<List<AdminGroupPerm>>(content);
                        Global.ObjClass.Permisions = perms;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            string error = ex.Message.ToString();
            throw;
        }
    }

    public async Task SetWorkPlace(string uid)
    {
        try
        {
            using (var client = new HttpClient { BaseAddress = new Uri(Global.MasApiUrl.qmsApiUrl) })
            {
                var api = "/qc/master/GetUserWorkPlace/" + uid;
                var response = await client.GetAsync(api);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    if (!string.IsNullOrEmpty(content))
                    {
                        var place = JsonConvert.DeserializeObject<UserWorkPlace>(content);
                        if (place != null)
                        {
                            Global.ObjClass.WorkingFactory = place.WorkingFact;
                            Global.ObjClass.WorkingSite = place.WorkingSite;
                            Global.ObjClass.WorkingLine = place.WorkingLine;
                        }
                    }
                }
                else
                {
                    alert = "workplace";
                    Close(alert);
                }
            }
        }
        catch (Exception ex)
        {
            Close(ex.Message.ToString());
        }
    }
}