using CodeAssessment.Application.Business.CarsProduction.Models;
using CodeAssessment.Application.Interface;
using Microsoft.EntityFrameworkCore;

namespace CodeAssessment.Application.Business.CarsProduction.Commands;
public class GetCarsProductionByIdQuery : IGetCarsProductionByIdQuery
{
    private readonly IAppDbContext _dbContext;

    public GetCarsProductionByIdQuery(IAppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<GetCarsProductivityModels> HandleAsync (Guid planningId)
    {
        try
        {
            var result = await _dbContext.Expectations.Include(x => x.Planning)
                        .Select(x => new GetCarsProductivityModels
                        {
                            PlanningId = x.PlanningId,
                            CandidateToken = x.Planning.CandidateToken,
                            Status = x.Planning.Status,
                            SlotPlanning = x.Planning.Slot,
                            ExpectationId = x.ExpectationId,
                            SlotExpectation = x.Slot,
                            CreatedBy = x.CreatedBy,
                            CreatedAt = x.CreatedAt,
                            CreatedAtServer = x.CreatedAtServer
                        })
                        .Where(x => x.PlanningId == planningId).FirstOrDefaultAsync();

            if (result == null)
            {
                throw new Exception("Data kosong");
            }

            return result;
        }
        catch (System.Exception ex)
        {
            throw new Exception("Message" + ex);
        }
    }
}