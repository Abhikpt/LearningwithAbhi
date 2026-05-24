using Microsoft.AspNetCore.Mvc;
using LearningwithAbhi.Server.Services;


namespace LearningwithAbhi.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EmployeeController : ControllerBase
{
    private readonly EmployeeService _service;

    public EmployeeController(EmployeeService service) => _service = service;

    [HttpGet]
    public IActionResult GetAll() => Ok(_service.GetAll());

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var employee = _service.GetById(id);
        return employee == null ? NotFound() : Ok(employee);
    }

    [HttpPost]
    public IActionResult Add(Employee employee)
    {
        _service.Add(employee);
        return Ok();
    }

    [HttpPut]
    public IActionResult Update(Employee employee)
    {
        _service.Update(employee);
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _service.Delete(id);
        return Ok();
    }
}