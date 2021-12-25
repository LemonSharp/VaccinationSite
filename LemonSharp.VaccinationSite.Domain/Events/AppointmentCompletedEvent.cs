using LemonSharp.VaccinationSite.Domain.AggregatesModel.VaccinationSiteAggregate;
using MediatR;

namespace LemonSharp.VaccinationSite.Domain.Events;

public record AppointmentCompletedEvent(
    long UserId,
    DateTime AppointmentDate,
    string AddressName,
    double AddressLongitude, 
    double AddressLatitude
) : INotification;
