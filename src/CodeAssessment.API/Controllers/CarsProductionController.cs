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
    public async Task<IActionResult> ExpectationCars([FromBody] RequestSaveModel request)
    {
        try
        {
            var result = await _carsProduction.CarsProductions(request.Plan, request.RequestCode);
            return Ok(ApiResponse<List<int>>.Success(result, "Data saved successfully", 200));
        }
        catch(Exception ex)
        {
            return BadRequest(ApiResponse<List<int>>.Failure(ex.Message, 400));
        }
    }

    [HttpGet("GetExpectationCars")]
    public async Task<IActionResult> GetListExpectationCars([FromQuery] RequestGetListModel request)
    {
        try
        {
            var result = await _getList.HandleAsync(request.Page, request.Size);
            return Ok(ApiResponse<List<GetCarsProductivityModels>>.Success(result, "Data saved successfully", 200));
        }
        catch(Exception ex)
        {
            return BadRequest(ApiResponse<List<GetCarsProductivityModels>>.Failure(ex.Message, 400));
        }
    }

    [HttpGet("GetExpectationCars/{planningId}")]
    public async Task<IActionResult> GetExpectationCarsById([FromRoute] Guid planningId)
    {
        try
        {
            var result = await _getById.HandleAsync(planningId);
            return Ok(ApiResponse<GetCarsProductivityModels>.Success(result, "Data saved successfully", 200));
        }
        catch(Exception ex)
        {
            return BadRequest(ApiResponse<GetCarsProductivityModels>.Failure(ex.Message, 400));
        }
    }
}