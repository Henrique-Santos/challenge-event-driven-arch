using EDA.Core.Mediator;
using EDA.Wallet.Application.Commands;
using EDA.Wallet.Application.Queries;
using EDA.Wallet.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace EDA.Wallet.Controllers;

[ApiController]
[Route("accounts")]
public class AccountController : ControllerBase
{
    private readonly IMediatorHandler _mediator;
    private readonly IAccountQueries _queries;

    public AccountController(IMediatorHandler mediator, IAccountQueries queries)
    {
        _mediator = mediator;
        _queries = queries;
    }

    [HttpPost]
    public async Task<ActionResult> CreateAccount(CreateAccountRequest request)
    {
        var command = new CreateAccountCommand(request.Client.Id, request.Client.Name, request.Client.Email);   

        var result = await _mediator.SendCommand(command);

        if (!result) return BadRequest();   

        var account = await _queries.GetAccount(command.Id);

        return Ok(account);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<GetAccountResponse>> GetAccount(Guid id)
    {
        var account = await _queries.GetAccount(id);

        if (account is null) return NotFound();

        return Ok(account);
    } 
}