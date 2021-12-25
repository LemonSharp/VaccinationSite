namespace LemonSharp.VaccinationSite.Application.DTOs;

public class AddSiteRequestDTO
{
    public string SiteName { get; set; }
    public string AddressName { get; set; }
    public double AddressLatitude { get; set; }
    public double AddressLongitude { get; set; }
    public int Capacity { get; set; }
}
