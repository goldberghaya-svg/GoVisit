using Core.Commands;
using Core.Queries;
using GoVisit.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GoVisit.Controllers;

[ApiController]
[Route("[controller]")]
public class AppointmentController : ControllerBase
{

    private readonly IMediator _mediator; 
    public AppointmentController(IMediator mediator) =>
        _mediator = mediator;
    

    [HttpGet]
    public async Task<IActionResult> Get(long id) =>
       Ok(await _mediator.Send(new GetAppointmentsForUserQuery(id)));
         

    [HttpPost]
    public async Task<IActionResult> Post([FromBody]AppointmentsForUser appointmentsForUser)
    {
        await _mediator.Send(new AddAppointmentsForUserCommand(appointmentsForUser));
        return Ok();
    }

    [HttpDelete]
    public async Task<IActionResult> CancelAppointment([FromBody]CancelAppointmentRequest request)
    {
        await _mediator.Send(new CancelAppointmentRequestCommand(request));
        return Ok();
    }

}
