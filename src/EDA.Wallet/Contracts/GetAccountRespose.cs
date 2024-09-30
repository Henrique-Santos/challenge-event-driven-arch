namespace EDA.Wallet.Contracts;

public record GetAccountResponse(Guid Id, AccountClient Client, decimal Balance, DateTime CreatedAt, DateTime UpdatedAt);

public record AccountClient(string Name, string Email, DateTime CreatedAt, DateTime UpdatedAt);