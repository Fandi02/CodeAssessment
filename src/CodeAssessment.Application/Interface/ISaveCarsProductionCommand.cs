namespace CodeAssessment.Application.Interface;

public  interface ISaveProductionCommand
{
    Task<Guid?> HandleAsync (List<decimal> plan, List<int> expectation, Guid requestCode);
}