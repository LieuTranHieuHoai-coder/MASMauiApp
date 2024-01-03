using AssetManagementApp.Business;
using AssetManagementApp.Data;
using AssetManagementApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MASMauiApp.Business
{
    public interface IMasterDataBusiness
    {
        Task<List<MasterDataBusiness>> GetCompanies();
        Task<List<Departments>> GetDepartments();
        Task<List<Departments>> GetDepartments(string companyCode);
        Task<List<Locations>> GetLocations();
        Task<List<Locations>> GetLocations(int deptId);
    }
}
