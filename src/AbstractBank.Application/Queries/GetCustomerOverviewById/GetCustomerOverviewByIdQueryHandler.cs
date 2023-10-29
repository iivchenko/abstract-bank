using AbstractBank.Domain.AccountAggregate;
using AbstractBank.Domain.CustomerAggregate;
using AbstractBank.Domain.TransactionAggregate;
using MediatR;

namespace AbstractBank.Application.Queries.GetCustomerOverviewById;

public sealed class GetCustomerOverviewByIdQueryHandler : IRequestHandler<GetCustomerOverviewByIdQuery, GetCustomerOverviewByIdQueryResponse>
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IAccountRepository _accountRepository;
    private readonly ITransactionRepository _transactionRepository;

    public GetCustomerOverviewByIdQueryHandler(
        ICustomerRepository customerRepository,
        IAccountRepository accountRepository,
        ITransactionRepository transactionRepository)
    {
        _customerRepository = customerRepository;
        _accountRepository = accountRepository;
        _transactionRepository = transactionRepository;
    }

    public async Task<GetCustomerOverviewByIdQueryResponse> Handle(GetCustomerOverviewByIdQuery request, CancellationToken cancellationToken)
    {
        // Note: The beauty of CQRS enables us to have different read model from write model
        // a.k.a for queries and commands. In order to speed up implementation 
        // I use write model here but if I will have more time I will split it.
        var customer = await _customerRepository.FindById(request.CustomerId);

        if (customer == null)
        {
            throw new AppException($"Customer with id '{request.CustomerId} doesn't exist in the system!");
        }

        var accounts = await _accountRepository.FindByCustomerId(customer.Id);

        return new GetCustomerOverviewByIdQueryResponse
        (
            customer.Id,
            customer.Name,
            customer.Surname,
            await
                accounts
                    .ToAsyncEnumerable()
                    .SelectAwait(async x =>
                    {
                        var transactions = await _transactionRepository.FindByAccountId(x.Id);
                        return new GetCustomerOverviewByIdQueryResponseAccount(
                            x.Id,
                            x.Credits,
                            transactions.Select(x => new GetCustomerOverviewByIdQueryResponseAccountTransaction(x.PreviousCredits, x.NewCredits)));
                    })
                    .ToListAsync()
        );
    }
}
