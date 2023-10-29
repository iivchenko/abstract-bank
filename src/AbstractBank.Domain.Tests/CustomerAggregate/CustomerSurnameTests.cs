using AbstractBank.Domain.Common;
using AbstractBank.Domain.CustomerAggregate;

namespace AbstractBank.Domain.Tests.CustomerAggregate;

public sealed class CustomerSurnameTests
{
    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public void Constructor_EmptyValue_Throws(string value)
    {
        // Arrange
        Action act = () => new CustomerSurname(value);

        // Act+Assert
        act
            .Should()
            .Throw<DomainException>()
            .WithMessage("Customer surname can't be null or empty!");
    }

    [Fact]
    public void Constructor_ValueExceedsMaxLength_Throws()
    {
        // Arrange
        var faker = new Faker();
        var value = faker.Random.String(CustomerSurname.MaxLength + 1);

        Action act = () => new CustomerSurname(value);

        //Act+Assert
        act
            .Should()
            .Throw<DomainException>()
            .WithMessage($"Customer surname '{value}' with length '{value.Length}' exceeds maximum allowed length of '{CustomerSurname.MaxLength}' characters.!");
    }

    [Fact]
    public void Constructor_ValidValue_SetsValueProperty()
    {
        // Arrange
        var faker = new Faker();
        var value = faker.Random.String(CustomerSurname.MaxLength);

        // Act
        var sut = new CustomerSurname(value);
        // Assert
        sut.Value.Should().Be(value);
    }
}