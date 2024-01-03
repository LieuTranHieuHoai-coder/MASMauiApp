using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssetManagementApp.Data
{
    public class DatabaseProcedure
    {
        private readonly AssetManagementOfflineDb db;
        public DatabaseProcedure()
        {
            db = AssetManagementOfflineDb.Instance.GetAwaiter().GetResult();
        }

        //master table
        public async Task<List<Company>> GetCompanies()
        {
            try
            {
                return await db.GetCompanies();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<int> SaveCompany(Company company)
        {
            try
            {
                var comp = await db.GetCompany(company.CompanyCode);
                if (comp != null)
                {
                    return await db.UpdateCompany(company);
                }
                return await db.InsertCompany(company);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<Department>> GetDepartments(string comCode)
        {
            try
            {
                return await db.GetDepartments(comCode);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<int> SaveDepartment(Department department)
        {
            try
            {
                var dept = await db.GetDepartment(department.DeptCode);
                if (dept != null)
                {
                    return await db.UpdateDepartment(department);
                }
                return await db.InsertDepartment(department);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<Location>> GetLocations(int deptId)
        {
            try
            {
                return await db.GetLocations(deptId);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<int> SaveLocation(Location location)
        {
            try
            {
                var loc = await db.GetLocation(location.LocationCode);
                if (loc != null)
                {
                    return await db.UpdateLocation(location);
                }
                return await db.InsertLocation(location);
            }
            catch (Exception)
            {

                throw;
            }
        }

        //check in document
        public async Task<CheckInDoc> GenCheckInDoc(string company, string user)
        {
            try
            {
                var lastSeq = 0;
                var searchStr = $"{company}CI{DateTime.Now:yyyyMMdd}/";
                var docNo = $"{company}CI{DateTime.Now:yyyyMMdd}/001";
                var found = await db.FindCheckInDoc(searchStr);
                if (found.Count > 0)
                {
                    var lastDoc = found.OrderByDescending(x => x.CheckInNo).FirstOrDefault();
                    var lastNumber = lastDoc.CheckInNo;
                    _ = int.TryParse(lastNumber.Split(new string[] { "/" }, StringSplitOptions.None)[1], out lastSeq);
                }
                if (lastSeq > 0)
                {
                    docNo = $"{searchStr}{lastSeq + 1:000}";
                }
                CheckInDoc doc = new CheckInDoc
                {
                    CheckInNo = docNo,
                    CreateBy = user,
                    CreateDate = DateTime.Now,
                    DocStatus = "NEW"
                };

                return await db.InsertCheckInDoc(doc) > 0 ? doc : null;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<CheckInDoc>> ListAllDocs()
        {
            try
            {
                return await db.ListAllCheckInDocs();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<CheckInDoc>> ListNewDocs()
        {
            try
            {
                return await db.ListNewCheckInDocs();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<CheckInAsset>> ListCheckInAssets(string checkInNo)
        {
            try
            {
                return await db.ListCheckInAssets(checkInNo);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<int> InsertCheckInAsset(CheckInAsset asset)
        {
            try
            {
                var found = await db.FindAssetCheckedIn(asset.AssetCode);
                if (found == null)
                {
                    return await db.InsertCheckInAsset(asset); 
                }
                return 0;
            }
            catch (Exception)
            {
                return -1;
            }
        }

        public async Task<int> UpdateCheckInAsset(CheckInAsset asset)
        {
            try
            {
                return await db.UpdateCheckInAsset(asset);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<int> UpdateCheckinDoc(CheckInDoc doc)
        {
            try
            {
                return await db.UpdateCheckInDoc(doc);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<int> DeleteCheckInDoc(CheckInDoc doc)
        {
            try
            {
                var listAsset = await db.ListCheckInAssets(doc.CheckInNo);
                var result = 0;
                if (await db.DeleteCheckInDoc(doc) > 0)
                {
                    result++;
                    foreach (var item in listAsset)
                    {
                        result += await db.DeleteCheckInAsset(item);
                    }
                }
                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<int> DeleteCheckInAsset(CheckInAsset asset)
        {
            try
            {
                return await db.DeleteCheckInAsset(asset);
            }
            catch (Exception)
            {

                throw;
            }
        }
        //asset location
        public async Task<int> SaveAssetLocation(AssetLocation asset)
        {
            try
            {
                var found = await db.GetAssetLocation(asset.AssetCode);
                if (found != null)
                {
                    return await db.UpdateAssetLocation(asset);
                }
                return await db.InsertAssetLocation(asset);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<int> UpdateAssetLocation(AssetLocation location)
        {
            try
            {
                return await db.UpdateAssetLocation(location);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<int> DeleteAssetLocation(AssetLocation location)
        {
            try
            {
                return await db.DeleteAssetLocation(location);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<List<AssetLocation>> GetAssetLocations()
        {
            try
            {
                return await db.GetAssetLocations();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<AssetLocationView>> GetNoneSyncAssetLocation()
        {
            try
            {
                return await db.GetNoneSyncAssetLocation();
            }
            catch (Exception)
            {

                throw;
            }
        }

        // sync data

        public async Task<int> DeleteAllMasterData()
        {
            try
            {
                var result = 0;
                result += await db.DeleteAllCompany();
                result += await db.DeleteAllDepartments();
                result += await db.DeleteAllLocations();
                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
