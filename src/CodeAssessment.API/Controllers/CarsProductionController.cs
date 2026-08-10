using CodeAssessment.Application.Business;
using CodeAssessment.Application.Interface;
using Microsoft.AspNetCore.Mvc;

namespace CodeAssessment.API.Controllers;

[ApiController]
[Route("[controller]")]
public class CarsProductionController : ControllerBase
{
    private ICarsProduction _carsProduction;

    public CarsProductionController(ICarsProduction carsProduction)
    {
        _carsProduction = carsProduction;
    }

    [HttpPost(Name = "ExpectationCars")]
    public async Task<List<int>> ExpectationCars([FromBody] List<decimal> plan)
    {
        return await _carsProduction.CarsProductions(plan);
    }
}