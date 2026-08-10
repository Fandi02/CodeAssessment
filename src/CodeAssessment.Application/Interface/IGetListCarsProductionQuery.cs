using CodeAssessment.Application.Business.CarsProduction.Models;

namespace CodeAssessment.Application.Interface;

public  interface IGetListCarsProductionQuery
{
    Task<List<GetCarsProductivityModels>> HandleAsync (int? Page, int? Size);
}