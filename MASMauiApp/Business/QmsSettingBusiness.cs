using MASMauiApp.Global;
using Newtonsoft.Json;
using QMS.Models;

namespace MASMauiApp.Business
{
    public class QmsSettingBusiness
    {
        public QmsSettingBusiness() { }
        public async Task<List<xFactory>> GetSites()
        {
            try
            {
                using (var client = new HttpClient { BaseAddress = new Uri(MasApiUrl.qmsApiUrl) })
                {
                    var api = "/qc/master/GetSites";
                    var response = await client.GetAsync(api);
                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        if (!string.IsNullOrEmpty(content))
                        {
                            return JsonConvert.DeserializeObject<List<xFactory>>(content);
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
        public async Task<List<xFactory>> GetFactories(string site)
        {
            try
            {
                using (var client = new HttpClient { BaseAddress = new Uri(MasApiUrl.qmsApiUrl) })
                {
                    var api = "/qc/master/GetFactories/" + site;
                    var response = await client.GetAsync(api);
                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        if (!string.IsNullOrEmpty(content))
                        {
                            return JsonConvert.DeserializeObject<List<xFactory>>(content);
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
        public async Task<List<xFactory>> GetSewLines(string site, string fact)
        {
            try
            {
                using (var client = new HttpClient { BaseAddress = new Uri(MasApiUrl.qmsApiUrl) })
                {
                    var api = $"/qc/master/GetSewLines?site={site}&fty={fact}";
                    var response = await client.GetAsync(api);
                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        if (!string.IsNullOrEmpty(content))
                        {
                            return JsonConvert.DeserializeObject<List<xFactory>>(content);
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
