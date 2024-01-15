using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagementApp.Business
{
    public class AssetLocationBusiness
    {
        public AssetLocationBusiness()
        {

        }

        public async Task<int> SetLocation(int locID, string assetCode, string user)
        {
            try
            {
                using (var client = new HttpClient { BaseAddress = new Uri(MASMauiApp.Global.MasApiUrl.masUrl) })
                {
                    var api = $"/api/SetLocation?locid={locID}&qr={assetCode}&user={user}";
                    var response = await client.GetAsync(api);
                    if (response.IsSuccessStatusCode)
                    {
                        return 1;
                    }
                    return 0;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<int> SyncLocation(Data.AssetLocation location)
        {
            try
            {
                using (var client = new HttpClient { BaseAddress = new Uri(MASMauiApp.Global.MasApiUrl.masUrl) })
                {
                    var api = $"/api/SyncLocation";
                    var content = new StringContent(JsonConvert.SerializeObject(location), Encoding.UTF8, "application/json");
                    var response = await client.PostAsync(api, content);
                    if (response.IsSuccessStatusCode)
                    {
                        return 1;
                    }
                    return 0;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
