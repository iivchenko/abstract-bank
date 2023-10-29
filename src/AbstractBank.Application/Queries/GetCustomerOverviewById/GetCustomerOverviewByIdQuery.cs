namespace AbstractBank.Application.Queries.GetCustomerOverviewById;

public sealed record GetCustomerOverviewByIdQuery(Guid CustomerId) : IQuery<GetCustomerOverviewByIdQueryResponse>;
