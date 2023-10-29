namespace AbstractBank.Application.Queries.GetCustomerOverviewById;

public sealed record GetCustomerOverviewByIdQueryResponse(
    Guid CustomerId,
    string CustomerName, 
    string CustomerSurname);