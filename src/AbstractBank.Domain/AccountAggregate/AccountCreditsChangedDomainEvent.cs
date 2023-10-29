namespace AbstractBank.Domain.AccountAggregate;

public sealed record AccountCreditsChangedDomainEvent(Guid AccountId, decimal PreviousCredits, decimal NewCredits) : IDomainEvent;
