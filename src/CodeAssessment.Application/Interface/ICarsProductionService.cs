namespace CodeAssessment.Application.Interface;

public  interface ICarsProductionService
{
    Task<List<int>> CarsProductions (List<decimal> plan, Guid requestCode);
}