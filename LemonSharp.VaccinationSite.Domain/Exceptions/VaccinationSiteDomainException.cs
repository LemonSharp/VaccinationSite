namespace LemonSharp.VaccinationSite.Domain.Exceptions;

public class VaccinationSiteDomainException : Exception
{
    public BusinessCode Code { get; }

    public VaccinationSiteDomainException()
    { }

    public VaccinationSiteDomainException(BusinessCode code, string message)
        : base(message)
    {
        Code = code;
    }


    public VaccinationSiteDomainException(BusinessCode code, string message, Exception innerException)
        : base(message, innerException)
    {
        Code = code;
    }
}
