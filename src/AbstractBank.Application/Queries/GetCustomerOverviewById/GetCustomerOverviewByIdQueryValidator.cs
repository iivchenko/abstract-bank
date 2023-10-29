using FluentValidation;

namespace AbstractBank.Application.Queries.GetCustomerOverviewById;

public sealed class GetCustomerOverviewByIdQueryValidator : AbstractValidator<GetCustomerOverviewByIdQuery>
{
    public GetCustomerOverviewByIdQueryValidator()
    {
        RuleFor(x => x.CustomerId).NotEmpty();
    }
}
