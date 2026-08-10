using CodeAssessment.Application.Business.CarsProduction.Models;

namespace CodeAssessment.Application.Interface;

public  interface IGetCarsProductionByIdQuery
{
    Task<GetCarsProductivityModels> HandleAsync (Guid planningId);
}