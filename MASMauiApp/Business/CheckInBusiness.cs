using AssetManagementApp.Data;
using Newtonsoft.Json;
using System.Text;

namespace AssetManagementApp.Business
{
    public class CheckInBusiness
    {
        public CheckInBusiness()
        {

        }

        public async Task<Models.CheckInDocs> GenerateNewDoc(string company, string username)
        {
            try
            {
                using (var client = new HttpClient { BaseAddress = new Uri("http://192.168.1.42:7000") })
                {
                    var api = $"/api/CreateCheckDoc?company={company}&user={username}";
                    var response = await client.GetAsync(api);
                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        if (!string.IsNullOrEmpty(content))
                        {
                            var docs = JsonConvert.DeserializeObject<Models.CheckInDocs>(content);
                            return docs;
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

        public async Task<Models.CheckInDocs> SyncCheckInDoc(CheckInDoc doc)
        {
            try
            {
                using (var client = new HttpClient { BaseAddress = new Uri("http://192.168.1.42:7000") })
                {
                    var api = $"/api/SyncCheckIn";
                    var content = new StringContent(JsonConvert.SerializeObject(doc), Encoding.UTF8, "application/json");
                    var response = await client.PostAsync(api, content);
                    if (response.IsSuccessStatusCode)
                    {
                        var data = await response.Content.ReadAsStringAsync();
                        if (!string.IsNullOrEmpty(data))
                        {
                            var checkInDocs = JsonConvert.DeserializeObject<Models.CheckInDocs>(data);
                            return checkInDocs;
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

        public async Task<int> DeleteCheckInDoc(int id)
        {
            try
            {
                using (var client = new HttpClient { BaseAddress = new Uri("http://192.168.1.42:7000") })
                {
                    var api = $"/api/DeleteCheckDoc/{id}";
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

        public async Task<int> CheckInAsset(Models.CheckInAssets assets)
        {
            try
            {
                using (var client = new HttpClient { BaseAddress = new Uri("http://192.168.1.42:7000") })
                {
                    var api = "/api/CheckIn";
                    var content = new StringContent(JsonConvert.SerializeObject(assets), Encoding.UTF8, "application/json");
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

        public async Task<List<Models.CheckInDocs>> ListNewCheckInDocs()
        {
            try
            {
                using (var client = new HttpClient { BaseAddress = new Uri("http://192.168.1.42:7000") })
                {
                    var api = "/api/ListNewCheckInDoc";
                    var response = await client.GetAsync(api);
                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        if (!string.IsNullOrWhiteSpace(content))
                        {
                            return JsonConvert.DeserializeObject<List<Models.CheckInDocs>>(content);
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
    }
}
