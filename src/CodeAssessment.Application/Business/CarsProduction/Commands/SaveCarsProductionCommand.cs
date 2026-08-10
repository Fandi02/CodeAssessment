using System;
using CodeAssessment.Application.Interface;
using CodeAssessment.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CodeAssessment.Application.Business.CarsProduction.Commands;
public class SaveCarsProduction : ISaveProductionCommand
{
    private readonly IAppDbContext _dbContext;

    public SaveCarsProduction(IAppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Guid?> HandleAsync (List<decimal> plan, List<int> expectation, Guid requestCode)
    {
        try
        {
            var dateTime = DateTime.UtcNow;
            var dateTimeServer = DateTime.UtcNow.AddHours(7);

            var checkRequestCode = await _dbContext.Plannings.AnyAsync(x => x.RequestCode == requestCode);

            if (checkRequestCode)
            {
                throw new Exception("Request Code sudah tersimpan di database");
            }

            var savePlanning = new Planning
            {
                PlanningId = Guid.NewGuid(),
                Slot = string.Join(",", plan),
                CandidateToken = "VEH-FANDI",
                RequestCode = requestCode,
                Status = true,
            CreatedAt = dateTime,
            CreatedAtServer = dateTimeServer
            };

            var saveExpectation = new Expectation
            {
                ExpectationId = Guid.NewGuid(),
                Slot = string.Join(",", plan),
                PlanningId = savePlanning.PlanningId,
                CreatedAt = dateTime,
                CreatedAtServer = dateTimeServer
            };

            await _dbContext.Plannings.AddAsync(savePlanning);
            await _dbContext.Expectations.AddAsync(saveExpectation);

            await _dbContext.SaveChangesAsync();

            return savePlanning.PlanningId;
        }
        catch (System.Exception ex)
        {
            throw new Exception("Message" + ex);
        }
    }
}