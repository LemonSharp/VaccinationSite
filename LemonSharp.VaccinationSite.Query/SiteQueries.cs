using Dapper;
using LemonSharp.VaccinationSite.Query.DTOs;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace LemonSharp.VaccinationSite.Query;

public class SiteQueries: ISiteQueries
{
    private readonly string _connStr;
    public SiteQueries(IConfiguration configuration)
    {
        _connStr = configuration.GetConnectionString("VaccinationSite");
    }
    
    public async Task<SiteListDTO[]> GetSiteListAsync(SiteListRequestDTO request)
    {
        var whereFilter = string.Empty;
        if (!string.IsNullOrEmpty(request.Keyword))
        {
            whereFilter = " WHERE (SiteName LIKE N'%'+@Keyword+N'%' OR AddressName LIKE N'%'+@Keyword+N'%') ";
        }
        var sql = "";
        if (request.AddressLatitude.HasValue && request.AddressLongitude.HasValue)
        {
            sql = $@"
SELECT Id AS SiteId, * FROM [dbo].[VaccinationSites] {whereFilter}
ORDER BY ((AddressLatitude-@AddressLatitude)*(AddressLatitude-@AddressLatitude) + (AddressLongitude-@AddressLongitude)*(AddressLongitude-@AddressLongitude)) ASC
";
        }
        else
        {
            sql = $@"SELECT Id AS SiteId, * FROM [dbo].[VaccinationSites] {whereFilter} ORDER BY SiteName";
        }

        await using var conn = new SqlConnection(_connStr);
        return (await conn.QueryAsync<SiteListDTO>(sql, request)).ToArray();
    }
    
    public async Task<SiteListDTO> GetSiteInfoByIdAsync(Guid siteId)
    {
        const string sql = "SELECT Id AS SiteId, * FROM [dbo].[VaccinationSites] WHERE Id = @siteId";
        await using var conn = new SqlConnection(_connStr);
        return await conn.QueryFirstOrDefaultAsync<SiteListDTO>(sql, new { siteId });
    }

    public async Task<SiteCapacityResponseDTO[]> GetSiteCapacityInfoAsync(SiteCapacityRequestDTO request)
    {
        var sql = @"
SELECT [Date], [Capacity], [Available] FROM dto.AppointmentRanges
WHERE SiteId = @SiteId AND [Date] >= @BeginDate AND [Date] <= @EndDate";
        await using var conn = new SqlConnection(_connStr);
        return (await conn.QueryAsync<SiteCapacityResponseDTO>(sql, request)).ToArray();
    }
}
