namespace CodeAssessment.Application.Interface;

public  interface ICarsProduction
{
    Task<List<int>> CarsProductions (List<decimal> plan);
}