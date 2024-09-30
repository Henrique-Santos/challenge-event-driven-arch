namespace EDA.Wallet.Contracts;

public record CreateAccountRequest(Client Client);

public record Client(Guid Id, string Name, string Email);