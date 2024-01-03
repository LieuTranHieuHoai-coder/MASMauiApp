using MASMauiApp.Models;
using Newtonsoft.Json;

namespace MASMauiApp.Services
{
    public class FactoryResponse : IFactory
    {
        public async Task<List<FactoryModel>> GetAllFactories()
        {
            var factoryList = new List<FactoryModel>();
            try
            {
                using (var client = new HttpClient())
                {
                    string url = Global.MasApiUrl.masUrl + "getFactory";
                    HttpResponseMessage response = client.GetAsync(url).Result;
                    string result = await response.Content.ReadAsStringAsync();
                    if (response.IsSuccessStatusCode)
                    { 
                        factoryList = JsonConvert.DeserializeObject<List<FactoryModel>>(result);
                    }
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }
            return factoryList;
        }
    }
}
