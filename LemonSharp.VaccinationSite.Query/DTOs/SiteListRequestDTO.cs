namespace LemonSharp.VaccinationSite.Query.DTOs;

public class SiteListRequestDTO
{
    public string Keyword { get; set; } = string.Empty;
    public double? AddressLatitude { get; set; }
    public double? AddressLongitude { get; set; }
}
