using AbstractBank.Domain.CustomerAggregate;
using MediatR;

namespace AbstractBank.Application.Queries.GetCustomerOverviewById;

public sealed class GetCustomerOverviewByIdQueryHandler : IRequestHandler<GetCustomerOverviewByIdQuery, GetCustomerOverviewByIdQueryResponse>
{
    private readonly ICustomerRepository _customerRepository;

    public GetCustomerOverviewByIdQueryHandler(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
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

        return new GetCustomerOverviewByIdQueryResponse
        (
            customer.Id,
            customer.Name,
            customer.Surname
        );
    }
}
