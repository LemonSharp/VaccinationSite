using System.ComponentModel.DataAnnotations;

namespace LemonSharp.VaccinationSite.Application.DTOs;

public class AddSiteRequestDTO
{
    [Required]
    public string SiteName { get; set; } = string.Empty;
    [Required]
    public string AddressName { get; set; } = string.Empty;
    public double AddressLatitude { get; set; }
    public double AddressLongitude { get; set; }
    public int Capacity { get; set; }
}
