namespace AbstractBank.Domain.AccountAggregate;

public sealed record NewAccountCreatedDomainEvent(Guid AccountId, Guid CustomerId) : IDomainEvent;