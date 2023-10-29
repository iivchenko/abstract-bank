namespace AbstractBank.Application.Commands.AddTransaction;

public sealed record AddTransactionCommand(Guid AccountId, decimal PreviousCredits, decimal NewCredits) : ICommand<AddTransactionCommandResponse>;
