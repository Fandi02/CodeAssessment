using CodeAssessment.API.Models;
using CodeAssessment.Application.Business;
using CodeAssessment.Application.Business.CarsProduction.Models;
using CodeAssessment.Application.Interface;
using Microsoft.AspNetCore.Mvc;

namespace CodeAssessment.API.Controllers;

[ApiController]
[Route("[controller]")]
public class CarsProductionController : ControllerBase
{
    private ICarsProductionService _carsProduction;
    private IGetListCarsProductionQuery _getList;
    private IGetCarsProductionByIdQuery _getById;

    public CarsProductionController(ICarsProductionService carsProduction, IGetListCarsProductionQuery getList, IGetCarsProductionByIdQuery getById)
    {
        _carsProduction = carsProduction;
        _getList = getList;
        _getById = getById;
    }

    [HttpPost(Name = "ExpectationCars")]
    public async Task<List<int>> ExpectationCars([FromBody] RequestSaveModel request)
    {
        return await _carsProduction.CarsProductions(request.Plan, request.RequestCode);
    }

    [HttpGet("GetExpectationCars")]
    public async Task<List<GetCarsProductivityModels>> GetListExpectationCars([FromQuery] RequestGetListModel request)
    {
        return await _getList.HandleAsync(request.Page, request.Size);
    }

    [HttpGet("GetExpectationCars/{planningId}")]
    public async Task<GetCarsProductivityModels> GetExpectationCarsById([FromRoute] Guid planningId)
    {
        return await _getById.HandleAsync(planningId);
    }
}