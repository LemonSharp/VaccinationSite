namespace LemonSharp.VaccinationSite.Query.DTOs;

public class SiteListDTO
{
    public Guid SiteId { get; set; }
    public string SiteName { get; set; } = string.Empty;
    public string AddressName { get; set; } = string.Empty;
    public double AddressLatitude { get; set; }
    public double AddressLongitude { get; set; }
    public int Capacity { get; set; }
}
