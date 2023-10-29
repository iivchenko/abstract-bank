using FluentValidation;

namespace AbstractBank.Application.Commands.AddTransaction;

public sealed class AddTransactionCommandValidator : AbstractValidator<AddTransactionCommand>
{
    public AddTransactionCommandValidator()
    {
        RuleFor(x => x.AccountId).NotEmpty();
        RuleFor(x => x.PreviousCredits).NotEqual(x => x.NewCredits);
    }
}
