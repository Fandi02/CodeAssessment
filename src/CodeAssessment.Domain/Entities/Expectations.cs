namespace CodeAssessment.Domain.Entities;

public class Expectation
{
    public Guid ExpectationId { get; set; }
    public string? Slot { get; set; }
    public string? CreatedBy { get; set; }
    public DateTime? CreatedAt { get; set; }
    public DateTime? CreatedAtServer { get; set; }
    public string? LastUpdatedBy { get; set; }
    public DateTime? LastUpdatedAt { get; set; }
    public DateTime? LastUpdatedAtServer { get; set; }

    public Guid? PlanningId { get; set; }
    public Planning? Planning { get; set; }
}