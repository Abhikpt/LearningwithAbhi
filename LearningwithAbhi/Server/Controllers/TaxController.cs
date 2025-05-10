using Microsoft.AspNetCore.Mvc;
using LearningwithAbhi.Shared.Services;

namespace LearningwithAbhi.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TaxController : ControllerBase
{
    private readonly TaxCalculationService _taxService;

    public TaxController(TaxCalculationService taxService)
    {
        _taxService = taxService;
    }

    [HttpPost("old")]
    public IActionResult CalculateOld([FromBody] TaxInput input)
    {
        var result = _taxService.CalculateOldRegime(input.Income, input.Investments);
        return Ok(result);
    }

    [HttpPost("new")]
    public IActionResult CalculateNew([FromBody] TaxInput input)
    {
        var result = _taxService.CalculateNewRegime(input.Income, input.StandardDeduction, input.Investments);
        return Ok(result);
    }
}

public class TaxInput
{
    public decimal Income { get; set; }
    public decimal Investments { get; set; }
    public decimal StandardDeduction { get; set; } = 0;
}
