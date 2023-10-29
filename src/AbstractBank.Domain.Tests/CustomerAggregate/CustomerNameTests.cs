using AbstractBank.Domain.AccountAggregate;
using AbstractBank.Domain.CustomerAggregate;

namespace AbstractBank.Domain.Tests.CustomerAggregate;

public sealed class CustomerNameTests
{
    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public void Constructor_EmptyValue_Throws(string value)
    {
        // Arrange
        Action act = () => new CustomerName(value);

        // Act+Assert
        act
            .Should()
            .Throw<DomainException>()
            .WithMessage("Customer name can't be null or empty!");
    }

    [Fact]
    public void Constructor_ValueExceedsMaxLength_Throws()
    {
        // Arrange
        var faker = new Faker();
        var value = faker.Random.String(CustomerName.MaxLength + 1);

        Action act = () => new CustomerName(value);

        //Act+Assert
        act
            .Should()
            .Throw<DomainException>()
            .WithMessage($"Customer name '{value}' with length '{value.Length}' exceeds maximum allowed length of '{CustomerName.MaxLength}' characters.!");
    }

    [Fact]
    public void Constructor_ValidValue_SetsValueProperty()
    {
        // Arrange
        var faker = new Faker();
        var value = faker.Random.String(CustomerName.MaxLength);

        // Act
        var sut = new CustomerName(value);
        // Assert
        sut.Value.Should().Be(value);
    }
}
