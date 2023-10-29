using AbstractBank.Domain.AccountAggregate;

namespace AbstractBank.Domain.Tests.AccountAggregate
{
    // Note:
    // Unit tests prety much similar to CustomerTests
    // In order to save some time I will implement tests
    // that CustomerTests missing like handling Domain Events
    public sealed class AccountTests
    {
        [Fact]
        public void AddTransaction_AllConditionsMet_CreditsUpdatedAndEventPublished()
        {
            // Arrange
            var accountId = Guid.NewGuid();
            var sut = new Account(accountId, Guid.NewGuid());

            // Act
            sut.AddTransaction(100);

            // Assert
            sut.Credits.Should().Be(100);
            sut.Events.Should().HaveCount(1);
            sut.Events.Should().Contain(x =>
                x.As<AccountCreditsChangedDomainEvent>().AccountId == accountId &&
                x.As<AccountCreditsChangedDomainEvent>().PreviousCredits == 0 &&
                x.As<AccountCreditsChangedDomainEvent>().NewCredits == 100);
        }
    }
}
