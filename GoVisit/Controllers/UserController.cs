using GoVisit.Domain;
using Microsoft.AspNetCore.Mvc;

namespace GoVisit.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{

    private readonly IUserRepository _repository;

    public UserController(IUserRepository repository) => 
        _repository = repository;

    [HttpGet]
    public async Task<IActionResult> Get(long id) =>
        Ok(await _repository.Get(id));

    [HttpPost]
    public async Task<IActionResult> Post(User user) =>
        Ok(_repository.Add(user));
}
