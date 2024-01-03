using AssetManagementApp.Models;
using MASMauiApp;
using MASMauiApp.Business;
using MASMauiApp.Global;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace AssetManagementApp.Business
{
    public class MasterDataBusiness : IMasterDataBusiness
    {
        public MasterDataBusiness()
        {

        }

        public async Task<List<Models.Companies>> GetCompanies()
        {
            try
            {
                using (var client = new HttpClient { BaseAddress = new Uri(MasApiUrl.amsUrl) })
                {
                    var api = "/api/GetCompanies";
                    var response = await client.GetAsync(api);
                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        if (!string.IsNullOrWhiteSpace(content))
                        {
                            return JsonConvert.DeserializeObject<List<Companies>>(content);
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

        public async Task<List<Models.Departments>> GetDepartments(string companyCode)
        {
            try
            {
                using (var client = new HttpClient { BaseAddress = new Uri(MasApiUrl.amsUrl) })
                {
                    var api = $"/api/GetDepartments?company={companyCode}";
                    var response = await client.GetAsync(api);
                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        if (!string.IsNullOrWhiteSpace(content))
                        {
                            return JsonConvert.DeserializeObject<List<Models.Departments>>(content);
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
        //GetLocations
        public async Task<List<Models.Locations>> GetLocations()
        {
            try
            {
                using (var client = new HttpClient { BaseAddress = new Uri(MasApiUrl.amsUrl) })
                {
                    var api = "/api/GetLocations";
                    var response = await client.GetAsync(api);
                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        if (!string.IsNullOrWhiteSpace(content))
                        {
                            return JsonConvert.DeserializeObject<List<Models.Locations>>(content);
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

        public async Task<List<Models.Locations>> GetLocations(int deptId)
        {
            try
            {
                using (var client = new HttpClient { BaseAddress = new Uri(MasApiUrl.amsUrl) })
                {
                    var api = "/api/GetDeptLocations/" + deptId;
                    var response = await client.GetAsync(api);
                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        if (!string.IsNullOrWhiteSpace(content))
                        {
                            return JsonConvert.DeserializeObject<List<Models.Locations>>(content);
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

        public async Task<List<Departments>> GetDepartments()
        {
            try
            {
                List<Departments> departments = new List<Departments>();
                using (var client = new HttpClient { BaseAddress = new Uri(MasApiUrl.amsUrl) })
                {
                    var api = "/api/ListAllDepartments";
                    var response = await client.GetAsync(api);
                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        if (!string.IsNullOrWhiteSpace(content))
                        {
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                            departments = JsonConvert.DeserializeObject<List<Departments>>(content);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
                            return departments;
                        }
                    }
                    return departments;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        Task<List<MasterDataBusiness>> IMasterDataBusiness.GetCompanies()
        {
            throw new NotImplementedException();
        }
    }
}
