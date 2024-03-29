﻿using MASMauiApp.Global;
using MASMauiApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MASMauiApp.Business
{
    public class RepairMethodBusiness
    {
        public async Task<List<Models.MASRepairMethods>> GetRepairMethods()
        {
            try
            {
                using (var client = new HttpClient { BaseAddress = new Uri(MasApiUrl.localUrl) })
                {
                    var api = "/api/RepairMethods/GetRepairMethods";
                    var response = await client.GetAsync(api);
                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        if (!string.IsNullOrWhiteSpace(content))
                        {
                            return JsonConvert.DeserializeObject<List<Models.MASRepairMethods>>(content);
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
        public async Task<Models.MASRepairMethods> GetMASRepairMethodsId(int id)
        {
            try
            {
                using (var client = new HttpClient { BaseAddress = new Uri(MasApiUrl.localUrl) })
                {
                    var api = "/api/RepairMethods/GetRepairMethodsId/" + id;
                    var response = await client.GetAsync(api);
                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        if (!string.IsNullOrWhiteSpace(content))
                        {
                            return JsonConvert.DeserializeObject<Models.MASRepairMethods>(content);
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
        public async Task<int> Insert(MASRepairMethods repair)
        {
            try
            {
                using (var client = new HttpClient { BaseAddress = new Uri(MasApiUrl.localUrl) })
                {
                    var api = "/api/RepairMethods/Insert";
                    var convert = JsonConvert.SerializeObject(repair);
                    var data = new StringContent(convert, Encoding.UTF8,"application/json");
                    var response = await client.PostAsync(api,data);
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
