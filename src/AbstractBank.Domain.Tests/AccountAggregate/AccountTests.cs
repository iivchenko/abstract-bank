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
            var customerId = Guid.NewGuid();
            var sut = new Account(accountId, customerId);

            // Act
            sut.AddTransaction(100);

            // Assert
            sut.Credits.Should().Be(100);
            sut.Events.Should().HaveCount(2);

            var newAccountEvent = sut.Events.Single(x => x is NewAccountCreatedDomainEvent) as NewAccountCreatedDomainEvent;

            newAccountEvent.CustomerId.Should().Be(customerId);
            newAccountEvent.AccountId.Should().Be(accountId);

            var creditsChangedEvent = sut.Events.Single(x => x is AccountCreditsChangedDomainEvent) as AccountCreditsChangedDomainEvent;

            creditsChangedEvent.AccountId.Should().Be(accountId);
            creditsChangedEvent.PreviousCredits.Should().Be(0);
            creditsChangedEvent.NewCredits.Should().Be(100);
        }
    }
}
