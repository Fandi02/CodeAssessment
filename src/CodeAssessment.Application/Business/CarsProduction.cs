using CodeAssessment.Application.Business.CarsProduction.Commands;
using CodeAssessment.Application.Interface;

namespace CodeAssessment.Application.Business;
public class CarsProductionService : ICarsProductionService
{
    private ISaveProductionCommand _saveCars;
    public CarsProductionService(ISaveProductionCommand saveCars)
    {
        _saveCars = saveCars;
    }
    public async Task<List<int>> CarsProductions (List<decimal> plan, Guid requestCode)
    {    
        if(plan is null || plan.Count == 0)
            throw new ArgumentException("Plan tidak boleh kosong.");
        
        for (int i = 0; i < plan.Count; i++)
        {
            if (plan[i] < 0)
                throw new ArgumentException($"Slot {i + 1}: nilai negatif tidak valid.");

            if (plan[i] != Math.Truncate(plan[i]))
                throw new ArgumentException($"Slot {i + 1}: nilai pecahan tidak valid.");
        }

        var expectationResult = new List<int>();

        var total = plan.Sum();
        var planLength = plan.Count();
        var totalLength = plan.Count(x => x != 0);
        

        int nilai = Convert.ToInt32(total/totalLength);
        var sisaNilai = total%totalLength;

        for (int i = 0; i < planLength; i++)
        {
            if (plan[i] == 0)
            {
                expectationResult.Add(0);
            }
            else
            {
                expectationResult.Add(nilai);
            }
        }

        var sortedPlan = plan
            .Select((value, index) => new { Value = value, Index = index })
            .OrderByDescending(x => x.Value)
            .ToList();

        for (int i = 0; i < sortedPlan.Count; i++)
        {
            if (sisaNilai == 0)
                break;

            var originalIndex = sortedPlan[i].Index;
            expectationResult[originalIndex] += 1;
            sisaNilai -= 1;
        }

        try
        {
            await _saveCars.HandleAsync(plan, expectationResult, requestCode);
        }
        catch (System.Exception ex)
        {
            throw new Exception("Message" + ex);
        }

        return expectationResult;
    }
}