using MASMauiApp.Global;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MASMauiApp.Business
{
    public class HistoryRepairBusiness
    {
        public async Task<List<Models.MASHistoryRepair>> GetMASHistoryRepair()
        {
            try
            {
                using (var client = new HttpClient { BaseAddress = new Uri(MasApiUrl.localUrl) })
                {
                    var api = "/api/MASHistoryRepair/GetMASHistoryRepair";
                    var response = await client.GetAsync(api);
                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        if (!string.IsNullOrWhiteSpace(content))
                        {
                            return JsonConvert.DeserializeObject<List<Models.MASHistoryRepair>>(content);
                        }
                    }
                    return null;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<Models.MASHistoryRepair> GetMASHistoryRepairId(int id)
        {
            try
            {
                using (var client = new HttpClient { BaseAddress = new Uri(MasApiUrl.localUrl) })
                {
                    var api = "/api/HistoryRepair/GetMASHistoryRepairId/" + id;
                    var response = await client.GetAsync(api);
                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        if (!string.IsNullOrWhiteSpace(content))
                        {
                            return JsonConvert.DeserializeObject<Models.MASHistoryRepair>(content);
                        }
                    }
                    return null;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<List<Models.MASHistoryRepair>> GetMASHistoryRepairAsset(string code)
        {
            try
            {
                using (var client = new HttpClient { BaseAddress = new Uri(MasApiUrl.localUrl) })
                {
                    var api = "/api/HistoryRepair/GetMASHistoryRepairAsset/" + code;
                    var response = await client.GetAsync(api);
                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        if (!string.IsNullOrWhiteSpace(content))
                        {
                            return JsonConvert.DeserializeObject<List<Models.MASHistoryRepair>>(content);
                        }
                    }
                    return null;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<List<ViewModels.MASHistoryRepairView>> GetMASHistoryRepairDetails(string code)
        {
            try
            {
                using (var client = new HttpClient { BaseAddress = new Uri(MasApiUrl.localUrl) })
                {
                    var api = "/api/HistoryRepair/GetMASHistoryRepairDetails?code=" + code;
                    var response = await client.GetAsync(api);
                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        if (!string.IsNullOrWhiteSpace(content))
                        {
                            return JsonConvert.DeserializeObject<List<ViewModels.MASHistoryRepairView>>(content);
                        }
                    }
                    return null;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<List<ViewModels.MASHistoryRepairView>> GetListMASHistoryRepair()
        {
            try
            {
                using (var client = new HttpClient { BaseAddress = new Uri(MasApiUrl.localUrl) })
                {
                    var api = "/api/HistoryRepair/GetListMASHistoryRepair";
                    var response = await client.GetAsync(api);
                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        if (!string.IsNullOrWhiteSpace(content))
                        {
                            return JsonConvert.DeserializeObject<List<ViewModels.MASHistoryRepairView>>(content);
                        }
                    }
                    return null;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<int> Insert(Models.MASHistoryRepair repair)
        {
            try
            {
                using (var client = new HttpClient { BaseAddress = new Uri(MasApiUrl.localUrl) })
                {
                    var api = "/api/historyrepair/Insert";
                    var convert = JsonConvert.SerializeObject(repair);
                    var data = new StringContent(convert, Encoding.UTF8, "application/json");
                    var response = await client.PostAsync(api, data);
                    if (response.IsSuccessStatusCode)
                    {
                        return 1;
                    }
                    return 0;
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                return 0;
            }
        }
        public async Task<int> Update(Models.MASHistoryRepair repair)
        {
            try
            {
                using (var client = new HttpClient { BaseAddress = new Uri(MasApiUrl.localUrl) })
                {
                    var api = "/api/HistoryRepair/Update";
                    var convert = JsonConvert.SerializeObject(repair);
                    var data = new StringContent(convert, Encoding.UTF8, "application/json");
                    var response = await client.PutAsync(api, data);
                    if (response.IsSuccessStatusCode)
                    {
                        return 1;
                    }

                    return 0;
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                return 0;
            }
        }
    }
}
