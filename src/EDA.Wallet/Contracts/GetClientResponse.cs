namespace EDA.Wallet.Contracts;

public record GetClientResponse(Guid Id, string Name, string Email, DateTime CreatedAt, DateTime UpdatedAt);