using AbstractBank.Application.Common;
using AbstractBank.Application.Queries.GetCustomerOverviewById;
using AbstractBank.Domain.CustomerAggregate;

namespace AbstractBank.Application.Tests.Queries.GetCustomerOverviewById;

public sealed class GetCustomerOverviewByIdQueryHandlerTests
{
    private const string Name = "Name";
    private const string Surname = "Surname";

    private readonly ICustomerRepository _customerRepository;

    private readonly GetCustomerOverviewByIdQueryHandler _sut;

    public GetCustomerOverviewByIdQueryHandlerTests()
    {
        _customerRepository = Substitute.For<ICustomerRepository>();

        _sut = new GetCustomerOverviewByIdQueryHandler(_customerRepository);
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
        var customer = new Customer(customerId, Name, Surname);
        var request = new GetCustomerOverviewByIdQuery(customerId);

        _customerRepository
            .FindById(customerId)
            .Returns(customer);

        // Act 
        var response = await _sut.Handle(request, CancellationToken.None);

        //Assert
        response.CustomerId.Should().Be(customerId);
        response.CustomerName.Should().Be(Name);
        response.CustomerSurname.Should().Be(Surname);
    }
}
