namespace AbstractBank.Application.Commands.CreateNewAccount;

public sealed record CreateNewAccountCommand(Guid CustomerId, decimal Change) : ICommand<CreateNewAccountCommandResponse>;
