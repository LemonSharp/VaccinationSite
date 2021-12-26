using LemonSharp.VaccinationSite.Domain.Events;
using LemonSharp.VaccinationSite.Domain.Exceptions;
using LemonSharp.VaccinationSite.Domain.SeedWork;

namespace LemonSharp.VaccinationSite.Domain.AggregatesModel.VaccinationSiteAggregate;

public class Site : Entity, IAggregateRoot
{
    public string SiteName { get; private set; }

    /// <summary>
    /// 经度
    /// </summary>
    public double AddressLongitude { get; private set; }

    /// <summary>
    /// 纬度
    /// </summary>
    public double AddressLatitude { get; private set; }

    /// <summary>
    /// 地址名
    /// </summary>
    public string AddressName { get; private set; }

    public int Capacity { get; private set; }

    private readonly List<AppointmentRange> _appointmentRanges;

    public IReadOnlyCollection<AppointmentRange> AppointmentRanges => _appointmentRanges;

    public Site()
    {
    }

    public Site(string siteName, string addressName, double addressLongitude, double addressLatitude, int capacity)
    {
        SiteName = siteName;
        AddressName = addressName;
        AddressLongitude = addressLongitude;
        AddressLatitude = addressLatitude;
        Capacity = capacity;
        _appointmentRanges = new List<AppointmentRange>();
    }

    public void CreateAppointment(Guid userId, DateTime appointmentDate)
    {
        var appointmentRange = AppointmentRanges.SingleOrDefault(x => x.Date == appointmentDate);

        // TODO 校验选的是过去的日子
        if (appointmentRange == null)
        {
            appointmentRange = new AppointmentRange(appointmentDate, Capacity);
            _appointmentRanges.Add(appointmentRange);
        }

        if (appointmentRange.IfAvailable())
        {
            throw new VaccinationSiteDomainException(BusinessCode.AppointmentFull, "所选时间段已满");
        }

        appointmentRange.CreateAppointment();

        AddDomainEvent(new AppointmentCompletedEvent(userId, appointmentRange.Date, AddressName, AddressLongitude, AddressLatitude));
    }

    public void CancelAppointment(Guid userId, DateTime appointmentDate)
    {
        var appointmentRange = AppointmentRanges.SingleOrDefault(x => x.Date == appointmentDate);

        appointmentRange?.CancelAppointment();

        AddDomainEvent(new AppointmentCanceledEvent(userId, appointmentDate));
    }
}
