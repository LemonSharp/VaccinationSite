namespace LemonSharp.VaccinationSite.Query.DTOs;

public class SiteCapacityResponseDTO
{
    public DateTime Date { get; set; }
    public int Capacity { get; set; }
    public int Available { get; set; }
}
