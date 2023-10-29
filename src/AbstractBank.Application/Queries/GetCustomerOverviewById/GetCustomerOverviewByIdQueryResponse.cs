namespace AbstractBank.Application.Queries.GetCustomerOverviewById;

public sealed record GetCustomerOverviewByIdQueryResponse(
    Guid CustomerId,
    string CustomerName, 
    string CustomerSurname,
    Guid? CurrentAccountId,
    IEnumerable<GetCustomerOverviewByIdQueryResponseAccount> Accounts);

public sealed record GetCustomerOverviewByIdQueryResponseAccount(Guid AccountId, decimal Credits, IEnumerable<GetCustomerOverviewByIdQueryResponseAccountTransaction> Transactions);

public sealed record GetCustomerOverviewByIdQueryResponseAccountTransaction(decimal PreviusCredits, decimal NewCredits);