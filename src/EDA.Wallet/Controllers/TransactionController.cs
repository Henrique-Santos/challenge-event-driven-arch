using EDA.Core.Mediator;
using EDA.Wallet.Application.Commands;
using EDA.Wallet.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace EDA.Wallet.Controllers;

[ApiController]
[Route("transactions")]
public class TransactionController : ControllerBase
{
    private readonly IMediatorHandler _mediator;

    public TransactionController(IMediatorHandler mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<ActionResult> CreateTransaction(CreateTransactionRequest request)
    {
        var command = new CreateTransactionCommand(request.AccountIdFrom, request.AccountIdTo, request.Amount);

        var result = await _mediator.SendCommand(command);

        return result ? Ok() : BadRequest();
    }
}