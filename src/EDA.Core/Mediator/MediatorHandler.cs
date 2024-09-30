using EDA.Core.Messages;
using MediatR;

namespace EDA.Core.Mediator;

public class MediatorHandler : IMediatorHandler 
{
    private readonly IMediator _mediator;

    public MediatorHandler(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<bool> SendCommand<T>(T command) where T : Command
    {
        return await _mediator.Send(command);
    }
}