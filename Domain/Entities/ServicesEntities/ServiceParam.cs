namespace Domain.Entities.ServicesEntities
{
    public record ServiceParam(string serviceName,
        string description,
        ServiceType serviceType,
        decimal price,
        TimeSpan duration);
}
