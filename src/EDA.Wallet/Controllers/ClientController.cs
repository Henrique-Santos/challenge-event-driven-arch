using EDA.Core.Mediator;
using EDA.Wallet.Application.Commands;
using EDA.Wallet.Application.Queries;
using EDA.Wallet.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace EDA.Wallet.Controllers;

[ApiController]
[Route("clients")]
public class ClientController : ControllerBase
{
    private readonly IMediatorHandler _mediator;
    private readonly IClientQueries _queries;

    public ClientController(IMediatorHandler mediator, IClientQueries queries)
    {
        _mediator = mediator;
        _queries = queries;
    }

    [HttpPost]
    public async Task<ActionResult> CreateClient(CreateClientRequest request)
    {
        var command = new CreateClientCommand(request.Name, request.Email);

        var result = await _mediator.SendCommand(command);
        
        if (!result) return BadRequest();

        var client = await _queries.GetClient(command.Id);

        return Ok(client);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<GetClientResponse>> GetClient(Guid id)
    {
        var client = await _queries.GetClient(id);

        if (client is null) return NotFound();

        return Ok(client);
    }
}