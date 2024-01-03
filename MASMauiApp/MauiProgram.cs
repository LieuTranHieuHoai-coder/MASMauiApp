using Microsoft.Extensions.Logging;
using CommunityToolkit.Maui;
using ZXing.Net.Maui.Controls;
using MASMauiApp.Services;
using MASMauiApp.Business;
using AssetManagementApp.Business;
using ZXing.Net.Maui;
using CurrieTechnologies.Razor.SweetAlert2;

namespace MASMauiApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .UseBarcodeReader()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                })
            #region
                .ConfigureMauiHandlers(h =>
                {
                    h.AddHandler(typeof(ZXing.Net.Maui.Controls.CameraBarcodeReaderView), typeof(CameraBarcodeReaderViewHandler));
                    h.AddHandler(typeof(ZXing.Net.Maui.Controls.CameraView), typeof(CameraViewHandler));
                    h.AddHandler(typeof(ZXing.Net.Maui.Controls.BarcodeGeneratorView), typeof(BarcodeGeneratorViewHandler));
                });
            #endregion
            builder.Services.AddMauiBlazorWebView();
            builder.Services.AddTransient<GoBack>();
            builder.Services.AddLocalization();
#if DEBUG

            builder.Services.AddBlazorWebViewDeveloperTools();
            builder.Logging.AddDebug();
#endif
            builder.Services.AddSingleton<IFactory, FactoryResponse>();
            builder.Services.AddSingleton<IMasterDataBusiness, MasterDataBusiness>();
            builder.Services.AddSweetAlert2();
            return builder.Build();
        }
    }
}
