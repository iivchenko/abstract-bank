using AbstractBank.Domain.AccountAggregate;
using AbstractBank.Domain.CustomerAggregate;

namespace AbstractBank.Domain.Tests.CustomerAggregate;

public sealed class CustomerTests
{
    private const string Name = "Name";
    private const string Surname = "Surname";
    private const string Code = "CODE_01";

    [Fact]
    public void Create_IdIsEmpty_Throws()
    {
        // Arrange
        Action act = () => CreateCustomer(id: Guid.Empty);

        // Act+Assert
        act
            .Should()
            .Throw<DomainException>()
            .WithMessage("Customer id can't be empty!");
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("  ")]
    public void Create_NameIsNull_Throws(string name)
    {
        // Arrange
        Action act = () => CreateCustomer(name: name);

        // Act+Assert
        act
            .Should()
            .Throw<DomainException>()
            .WithMessage("Customer name can't be null or empty!");
    }

    [Fact]
    public void Create_AllConditionsAreMet_ReturnSuccessfullyCreatedCustomer()
    {
        // Arrange
        var expectedId = Guid.NewGuid();
        var expectedName = Name;
        var expectedSurname = Surname;

        // Act
        var sut = CreateCustomer(expectedId, expectedName, expectedSurname);

        // Assert
        sut.Id.Should().Be(expectedId);
        sut.Name.Value.Should().Be(expectedName);
        sut.Surname.Value.Should().Be(expectedSurname);
    }

    [Fact]
    public void AddAccount_AccountIdIsEmpty_Throws()
    {
        // Arrange
        var id = Guid.NewGuid();
        var sut = CreateCustomer(id);

        // Act
        Action act = () => sut.AddAccount(Guid.Empty);

        // Assert
        act
            .Should()
            .Throw<DomainException>()
            .WithMessage("Account id can't be empty!");
    }

    [Fact]
    public void AddAccount_AccountAlreadyAdded_Throws()
    {
        // Arrange
        var id = Guid.NewGuid();
        var accountId = Guid.NewGuid();
        var sut = CreateCustomer(id);

        sut.AddAccount(accountId);

        // Act
        Action act = () => sut.AddAccount(accountId);

        // Assert
        act
            .Should()
            .Throw<DomainException>()
            .WithMessage($"Account with id '{accountId}' already part of the customer.");
    }

    [Fact]
    public void AddAccount_AllConditionsMet_Success()
    {
        // Arrange
        var id = Guid.NewGuid();
        var accountId = Guid.NewGuid();
        var sut = CreateCustomer(id);

        // Act
        sut.AddAccount(accountId);

        // Assert
        sut
            .Accounts
            .Should()
            .Contain(accountId);
    }

    [Fact]
    public void SetAccount_AccountIdIsEmpty_Throws()
    {
        // Arrange
        var id = Guid.NewGuid();
        var sut = CreateCustomer(id);

        // Act
        Action act = () => sut.SetCurrentAccount(Guid.Empty);

        // Assert
        act
            .Should()
            .Throw<DomainException>()
            .WithMessage("Account id can't be empty!");
    }

    [Fact]
    public void SetAccount_AccountIsNotPartOfACustomer_Throws()
    {
        // Arrange
        var id = Guid.NewGuid();
        var accountId = Guid.NewGuid();
        var sut = CreateCustomer(id);

        // Act
        Action act = () => sut.SetCurrentAccount(accountId);

        // Assert
        act
            .Should()
            .Throw<DomainException>()
            .WithMessage($"Account with id '{accountId}' is not part of the customer.");
    }

    [Fact]
    public void SetAccount_AllConditionsMet_Success()
    {
        // Arrange
        var id = Guid.NewGuid();
        var accountId = Guid.NewGuid();
        var sut = CreateCustomer(id);

        sut.AddAccount(accountId);

        // Act
        sut.SetCurrentAccount(accountId);

        // Assert
        sut
            .CurrentAccount
            .Should()
            .Be(accountId);
    }

    private static Customer CreateCustomer(
        Guid? id = null,
        string name = Name,
        string surname = Surname)
    {
        return new Customer(id ?? Guid.NewGuid(), name, surname);
    }
}

