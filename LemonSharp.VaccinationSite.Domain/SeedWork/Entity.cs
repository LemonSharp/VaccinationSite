using LemonSharp.VaccinationSite.Domain.Events;

namespace LemonSharp.VaccinationSite.Domain.SeedWork
{
    public abstract class Entity
    {
        public Guid Id { get; protected set; }

        private List<IDomainEvent>? _domainEvents;
        public IReadOnlyCollection<IDomainEvent>? DomainEvents => _domainEvents?.AsReadOnly();

        public bool IsTransient()
        {
            return Id == default;
        }
        
        public void AddDomainEvent(IDomainEvent eventItem)
        {
            _domainEvents ??= new List<IDomainEvent>();
            _domainEvents.Add(eventItem);
        }

        public void RemoveDomainEvent(IDomainEvent eventItem)
        {
            _domainEvents?.Remove(eventItem);
        }

        public void ClearDomainEvents()
        {
            _domainEvents?.Clear();
        }
    }
}
