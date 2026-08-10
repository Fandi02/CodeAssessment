namespace CodeAssessment.Application.Business.CarsProduction.Models;

public class GetCarsProductivityModels
{
    public Guid? PlanningId { get; set; }
    public string? CandidateToken { get; set; }
    public bool Status { get; set; }
    public string? SlotPlanning { get; set; }
    public Guid? ExpectationId { get; set; }
    public string? SlotExpectation { get; set; }
    public string? CreatedBy { get; set; }
    public DateTime? CreatedAt { get; set; }
    public DateTime? CreatedAtServer { get; set; }
}