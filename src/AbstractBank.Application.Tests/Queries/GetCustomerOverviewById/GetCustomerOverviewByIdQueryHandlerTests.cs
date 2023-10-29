using AbstractBank.Application.Common;
using AbstractBank.Application.Queries.GetCustomerOverviewById;
using AbstractBank.Domain.AccountAggregate;
using AbstractBank.Domain.CustomerAggregate;
using AbstractBank.Domain.TransactionAggregate;

namespace AbstractBank.Application.Tests.Queries.GetCustomerOverviewById;

public sealed class GetCustomerOverviewByIdQueryHandlerTests
{
    private const string Name = "Name";
    private const string Surname = "Surname";

    private readonly ICustomerRepository _customerRepository;
    private readonly IAccountRepository _accountRepository;
    private readonly ITransactionRepository _transactionRespository;

    private readonly GetCustomerOverviewByIdQueryHandler _sut;

    public GetCustomerOverviewByIdQueryHandlerTests()
    {
        _customerRepository = Substitute.For<ICustomerRepository>();
        _accountRepository = Substitute.For<IAccountRepository>();
        _transactionRespository = Substitute.For<ITransactionRepository>();

        _sut = new GetCustomerOverviewByIdQueryHandler(_customerRepository, _accountRepository, _transactionRespository);
    }

    [Fact]
    public async Task Handle_CustomerDoesntExist_Throws()
    {
        // Arrange
        var customerId = Guid.NewGuid();
        var request = new GetCustomerOverviewByIdQuery(customerId);

        // Act 
        var act = () => _sut.Handle(request, CancellationToken.None);

        //Assert
        await act
            .Should()
            .ThrowAsync<AppException>()
            .WithMessage($"Customer with id '{customerId} doesn't exist in the system!");
    }

    [Fact]
    public async Task Handle_AllConditionsMet_Success()
    {
        // Arrange
        var customerId = Guid.NewGuid();
        var accountId = Guid.NewGuid();
        var transactionId = Guid.NewGuid();
        var customer = new Customer(customerId, Name, Surname);
        var account = new Account(accountId, customerId);
        var accounts = new List<Account> { account };
        var transaction = new Transaction(transactionId, accountId, 0, 100);
        var transactions = new List<Transaction> { transaction };
        var request = new GetCustomerOverviewByIdQuery(customerId);

        _customerRepository
            .FindById(customerId)
            .Returns(customer);

        _accountRepository
            .FindByCustomerId(customerId)
            .Returns(accounts);

        _transactionRespository
            .FindByAccountId(accountId)
            .Returns(transactions);

        // Act 
        var response = await _sut.Handle(request, CancellationToken.None);

        //Assert
        response.CustomerId.Should().Be(customerId);
        response.CustomerName.Should().Be(Name);
        response.CustomerSurname.Should().Be(Surname);
        response
            .Accounts
            .Should()
            .Contain(x =>
                    x.AccountId == accountId &&
                    x.Transactions.Any(y => y.PreviusCredits == 0 && y.NewCredits == 100));
    }
}
