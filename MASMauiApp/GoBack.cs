using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MASMauiApp
{
    public class GoBack
    {
        private static IJSRuntime jsruntime { get; set; }

        public GoBack(IJSRuntime jsruntime)
        {
            GoBack.jsruntime = jsruntime;
        }

        public static async Task gobackintime()
        {
            //microsoft.maui.platform;
            if (GoBack.jsruntime != null)
            {
                await GoBack.jsruntime.InvokeVoidAsync("goback");
            }
        }
    }
}
