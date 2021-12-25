namespace LemonSharp.VaccinationSite.Query.DTOs;

public class SiteCapacityRequestDTO
{
    public Guid SiteId { get; set; }
    public DateTime BeginDate { get; set; }
    public DateTime EndDate { get; set; }
}
