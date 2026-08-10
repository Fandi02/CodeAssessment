using CodeAssessment.Application.Business.CarsProduction.Models;
using CodeAssessment.Application.Interface;
using Microsoft.EntityFrameworkCore;

namespace CodeAssessment.Application.Business.CarsProduction.Commands;
public class GetListCarsProductionQuery : IGetListCarsProductionQuery
{
    private readonly IAppDbContext _dbContext;

    public GetListCarsProductionQuery(IAppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<GetCarsProductivityModels>> HandleAsync (int? Page = 1, int? Size = 10)
    {
        try
        {
            int pageNumber = Page ?? 1;
            int pageSize = Size ?? 10;

            var query = await _dbContext.Expectations.Include(x => x.Planning).OrderByDescending(x => x.CreatedAt).Skip((pageNumber-1)*pageSize).Take(pageSize).ToListAsync();

            if (!query.Any())
            {
                throw new Exception("Data kosong");
            }

            var result = query.Select(x => new GetCarsProductivityModels
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
            }).ToList();

            return result;
        }
        catch (System.Exception ex)
        {
            throw new Exception("Message" + ex);
        }
    }
}