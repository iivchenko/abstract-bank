using AbstractBank.Domain.AccountAggregate;
using AbstractBank.Domain.TransactionAggregate;
using MediatR;

namespace AbstractBank.Application.Events;

public sealed class AccountCreditsChangedHandler : INotificationHandler<AccountCreditsChangedDomainEvent>
{
    private readonly ITransactionRepository _transactionRepository;

    public AccountCreditsChangedHandler(ITransactionRepository transactionRepository)
    {
        _transactionRepository = transactionRepository;
    }
    
    public Task Handle(AccountCreditsChangedDomainEvent notification, CancellationToken cancellationToken)
    {
        var transaction = new Transaction(Guid.NewGuid(), notification.AccountId, notification.PreviousCredits, notification.NewCredits);

        return _transactionRepository.Create(transaction);
    }
}
