using AbstractBank.Domain.TransactionAggregate;
using MediatR;

namespace AbstractBank.Application.Commands.AddTransaction;

public sealed class AddTransactionCommandHandler : IRequestHandler<AddTransactionCommand, AddTransactionCommandResponse>
{
    private readonly ITransactionRepository _transactionRepository;

    public AddTransactionCommandHandler(ITransactionRepository transactionRepository)
    {
        _transactionRepository = transactionRepository;
    }

    public async Task<AddTransactionCommandResponse> Handle(AddTransactionCommand request, CancellationToken cancellationToken)
    {
        var transaction = new Transaction(Guid.NewGuid(), request.AccountId, request.PreviousCredits, request.NewCredits);

        await _transactionRepository.Create(transaction);

        return new AddTransactionCommandResponse(); 
    }
}
