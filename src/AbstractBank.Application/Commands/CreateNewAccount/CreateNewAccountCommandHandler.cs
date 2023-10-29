using AbstractBank.Domain.AccountAggregate;
using MediatR;

namespace AbstractBank.Application.Commands.CreateNewAccount;

public sealed class CreateNewAccountCommandHandler : IRequestHandler<CreateNewAccountCommand, CreateNewAccountCommandResponse>
{
    private readonly IAccountRepository _accountRepository;

    public CreateNewAccountCommandHandler(IAccountRepository accountRepository)
    {
        _accountRepository = accountRepository;
    }

    public async Task<CreateNewAccountCommandResponse> Handle(CreateNewAccountCommand request, CancellationToken cancellationToken)
    {
        var account = new Account(Guid.NewGuid(), request.CustomerId); 

        var newAccount = await _accountRepository.Create(account);

        if (request.Change != 0)
        {
            account.AddTransaction(request.Change);
        }

        return new CreateNewAccountCommandResponse(newAccount.Id);
    }
}
