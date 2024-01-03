using SQLite;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;

namespace AssetManagementApp.Data
{
    /// <summary>
    /// reference link https://learn.microsoft.com/en-us/xamarin/xamarin-forms/data-cloud/data/
    /// </summary>    
    public class AssetManagementOfflineDb
    {

        static SQLiteAsyncConnection connection;

        public static readonly AsyncLazy<AssetManagementOfflineDb> Instance = new AsyncLazy<AssetManagementOfflineDb>(async () =>
        {
            var instance = new AssetManagementOfflineDb();
            await connection.CreateTableAsync<Company>();
            await connection.CreateTableAsync<Department>();
            await connection.CreateTableAsync<Location>();
            await connection.CreateTableAsync<CheckInDoc>();
            await connection.CreateTableAsync<CheckInAsset>();
            await connection.CreateTableAsync<AssetLocation>();
            return instance;
        });

        public AssetManagementOfflineDb()
        {
            connection = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
        }

        //COMPANY
        public Task<int> InsertCompany(Company company)
        {
            try
            {
                return connection.InsertAsync(company);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Task<int> UpdateCompany(Company company)
        {
            try
            {
                return connection.UpdateAsync(company);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Task<int> DeleteCompany(Company company)
        {
            try
            {
                return connection.DeleteAsync(company);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Task<Company> GetCompany(string companycode)
        {
            try
            {
                return connection.Table<Company>().FirstOrDefaultAsync(x => x.CompanyCode == companycode);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Task<List<Company>> GetCompanies()
        {
            try
            {
                return connection.Table<Company>().ToListAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        //DEPARTMENTS
        public Task<int> InsertDepartment(Department department)
        {
            try
            {
                return connection.InsertAsync(department);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public Task<int> UpdateDepartment(Department department)
        {
            try
            {
                return connection.UpdateAsync(department);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public Task<int> DeleteDepartment(Department department)
        {
            try
            {
                return connection.DeleteAsync(department);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Task<Department> GetDepartment(string deptcode)
        {
            try
            {
                return connection.Table<Department>().FirstOrDefaultAsync(x => x.DeptCode == deptcode);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Task<List<Department>> GetDepartments()
        {
            try
            {
                return connection.Table<Department>().ToListAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Task<List<Department>> GetDepartments(string companyCode)
        {
            try
            {
                return connection.Table<Department>().Where(x => x.CompanyCode == companyCode).ToListAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        //LOCATIONS

        public Task<int> InsertLocation(Location location)
        {
            try
            {
                return connection.InsertAsync(location);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public Task<int> UpdateLocation(Location location)
        {
            try
            {
                return connection.UpdateAsync(location);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public Task<int> DeleteLocation(Location location)
        {
            try
            {
                return connection.DeleteAsync(location);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Task<Location> GetLocation(string loccode)
        {
            try
            {
                return connection.Table<Location>().FirstOrDefaultAsync(x => x.LocationCode == loccode);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Task<List<Location>> GetLocations()
        {
            try
            {
                return connection.Table<Location>().ToListAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Task<List<Location>> GetLocations(int deptId)
        {
            try
            {
                return connection.Table<Location>().Where(x => x.DeptId == deptId).ToListAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        //check in documents

        public Task<List<CheckInDoc>> FindCheckInDoc(string searchStr)
        {
            try
            {
                return connection.Table<CheckInDoc>().Where(x => x.CheckInNo.Contains(searchStr)).ToListAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Task<List<CheckInDoc>> ListAllCheckInDocs()
        {
            try
            {
                return connection.Table<CheckInDoc>().ToListAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Task<List<CheckInDoc>> ListNewCheckInDocs()
        {
            try
            {
                return connection.Table<CheckInDoc>()
                                .Where(x => x.DocStatus == "NEW")
                                .OrderByDescending(x => x.CreateDate)
                                .ToListAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Task<List<CheckInAsset>> ListCheckInAssets(string checkInNo)
        {
            try
            {
                return connection.Table<CheckInAsset>().Where(x => x.CheckInNo == checkInNo).ToListAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Task<CheckInAsset> FindAssetCheckedIn(string assetCode)
        {
            try
            {
                return connection.Table<CheckInAsset>().FirstOrDefaultAsync(x => x.AssetCode == assetCode);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Task<int> InsertCheckInDoc(CheckInDoc doc)
        {
            try
            {
                return connection.InsertAsync(doc);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public Task<int> InsertCheckInAsset(CheckInAsset asset)
        {
            try
            {
                return connection.InsertAsync(asset);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Task<int> UpdateCheckInAsset(CheckInAsset asset)
        {
            try
            {
                return connection.UpdateAsync(asset);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Task<int> DeleteCheckInDoc(CheckInDoc doc)
        {
            try
            {
                return connection.DeleteAsync(doc);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Task<int> DeleteCheckInAsset(CheckInAsset asset)
        {
            try
            {
                return connection.DeleteAsync(asset);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Task<int> UpdateCheckInDoc(CheckInDoc doc)
        {
            try
            {
                return connection.UpdateAsync(doc);
            }
            catch (Exception)
            {

                throw;
            }
        }

        // asset location
        public Task<AssetLocation> GetAssetLocation(string assetCode)
        {
            try
            {
                return connection.Table<AssetLocation>().FirstOrDefaultAsync(x => x.AssetCode == assetCode);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Task<int> InsertAssetLocation(AssetLocation asset)
        {
            try
            {
                return connection.InsertAsync(asset);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public Task<int> UpdateAssetLocation(AssetLocation asset)
        {
            try
            {
                return connection.UpdateAsync(asset);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Task<int> DeleteAssetLocation(AssetLocation location)
        {
            try
            {
                return connection.DeleteAsync(location);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Task<List<AssetLocation>> GetAssetLocations()
        {
            try
            {
                return connection.Table<AssetLocation>().ToListAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Task<List<AssetLocationView>> GetNoneSyncAssetLocation()
        {
            try
            {
                var sql = @"SELECT
	                            a.AssetCode,
	                            a.LocationId,
	                            a.UpdateAt,
	                            a.UpdateBy,
                                a.SyncStatus,
	                            b.LocationCode,
	                            b.LocationNameCN,
	                            b.LocationNameEN,
	                            b.LocationNameVN,
	                            c.CompanyCode,
	                            c.DeptNameCN,
	                            c.DeptNameEN,
	                            c.DeptNameVN 
                            FROM
	                            AssetLocation AS a
	                            INNER JOIN Location AS b ON a.LocationId = b.LocationId
	                            INNER JOIN Department AS c ON b.DeptId = c.DeptId 
                            WHERE
	                            a.SyncStatus = 'NONE'";
                return connection.QueryAsync<AssetLocationView>(sql);

                //return connection.Table<AssetLocation>().Where(x => x.SyncStatus == "NONE").ToListAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        //sync data

        public Task<int> DeleteAllCompany()
        {
            try
            {
                return connection.DeleteAllAsync<Company>();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Task<int> DeleteAllDepartments()
        {
            try
            {
                return connection.DeleteAllAsync<Department>();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Task<int> DeleteAllLocations()
        {
            try
            {
                return connection.DeleteAllAsync<Location>();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
