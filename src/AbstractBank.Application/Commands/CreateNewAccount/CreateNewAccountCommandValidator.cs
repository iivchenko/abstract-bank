using FluentValidation;

namespace AbstractBank.Application.Commands.CreateNewAccount;

public sealed class CreateNewAccountCommandValidator : AbstractValidator<CreateNewAccountCommand>
{
    public CreateNewAccountCommandValidator()
    {
        RuleFor(x => x.CustomerId).NotEmpty();
    }
}
