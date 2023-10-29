using AbstractBank.Domain.AccountAggregate;
using AbstractBank.Domain.CustomerAggregate;
using MediatR;

namespace AbstractBank.Application.Events;

internal class NewAccountCreatedHandler : INotificationHandler<NewAccountCreatedDomainEvent>
{
    private readonly ICustomerRepository _customerRepository;

    public NewAccountCreatedHandler(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task Handle(NewAccountCreatedDomainEvent notification, CancellationToken cancellationToken)
    {
        var customer = await _customerRepository.FindById(notification.CustomerId);

        if (customer == null)
        {
            throw new AppException($"Customer with id '{notification.CustomerId}' doesn't exist in the system!");
        }

        customer.SetCurrentAccount(notification.AccountId);
    }
}
