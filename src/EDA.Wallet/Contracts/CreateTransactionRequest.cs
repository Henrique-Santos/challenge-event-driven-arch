namespace EDA.Wallet.Contracts;

public record CreateTransactionRequest(Guid AccountIdFrom, Guid AccountIdTo, decimal Amount);