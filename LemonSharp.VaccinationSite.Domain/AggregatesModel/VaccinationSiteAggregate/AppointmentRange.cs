using LemonSharp.VaccinationSite.Domain.SeedWork;

namespace LemonSharp.VaccinationSite.Domain.AggregatesModel.VaccinationSiteAggregate;

public class AppointmentRange : Entity
{
    public long SiteId { get; private set; }
    public DateTime Date { get; private set; }

    public int Capacity { get; private set; }

    public int Available { get; private set; }

    public AppointmentRange(DateTime date, int capacity)
    {
        Date = date;
        Capacity = capacity;
        Available = capacity;
    }

    public bool IfAvailable() => Available > 0;

    public void CreateAppointment() => Available--;

    public void CancelAppointment() => Available++;
}
