using GoVisit.Domain;
using Microsoft.AspNetCore.Mvc;

namespace GoVisit.Controllers;

[ApiController]
[Route("[controller]")]
public class AppointmentController : ControllerBase
{

    private readonly IAppiontmentsForUserRepository _repository;
    public AppointmentController(IAppiontmentsForUserRepository repository) =>   
        _repository = repository;
    

    [HttpGet]
    public async Task<IActionResult> Get(long id) =>
       Ok((await _repository.Get())
        .Where(a=> a.UserId == id)
           .SelectMany(a => a.Appointments).ToList());
         

    [HttpPost]
    public async Task<IActionResult> Post([FromBody]AppointmentsForUser appointmentsForUser)
    {
        await _repository.Add(appointmentsForUser);
        return Ok();
    }

    [HttpDelete]
    public async Task<IActionResult> CancelMeeting([FromBody]CancelMeetingRequest request)
    {
        var appointmentsForUser = (await _repository.Get()).FirstOrDefault(a => a.UserId == request.UserId);
        appointmentsForUser.Appointments.RemoveAll(a => a.OfficeId == request.OfficeId);
        await _repository.Update(appointmentsForUser);
        return Ok();
    }

}
