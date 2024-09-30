using EDA.Balance.Domain.Repository;
using Microsoft.AspNetCore.Mvc;

namespace EDA.Balance.Controllers;

[ApiController]
[Route("balances")]
public class BalanceController : ControllerBase
{
    private readonly IAccountRepository _repository;

    public BalanceController(IAccountRepository repository)
    {
        _repository = repository;
    }

    [HttpGet("{accountId:guid}")]
    public async Task<ActionResult> GetBalance(Guid accountId)
    {
        var balance = await _repository.GetBalance(accountId);
        return Ok(balance);
    }
}