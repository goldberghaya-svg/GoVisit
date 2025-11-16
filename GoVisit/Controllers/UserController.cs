using Core.Commands;
using Core.Queries;
using GoVisit.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GoVisit.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{

    private readonly IMediator _mediator;

    public UserController(IMediator mediator) =>
        _mediator = mediator;

    [HttpGet]
    public async Task<IActionResult> Get(long id) =>
        Ok(await _mediator.Send(new GetUserQuery(id)));

    [HttpPost]
    public async Task<IActionResult> Post(User user) =>
        Ok(_mediator.Send(new AddUserCommand(user)));
}
