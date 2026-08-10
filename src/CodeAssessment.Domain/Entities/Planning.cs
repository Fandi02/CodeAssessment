namespace CodeAssessment.Domain.Entities;

public class Planning
{
    public Guid PlanningId { get; set; }
    public int RequestCode { get; set; }
    public string? CandidateToken { get; set; }
    public bool Status { get; set; }
    public string? CreatedBy { get; set; }
    public DateTime? CreatedAt { get; set; }
    public DateTime? CreatedAtServer { get; set; }
    public string? LastUpdatedBy { get; set; }
    public DateTime? LastUpdatedAt { get; set; }
    public DateTime? LastUpdatedAtServer { get; set; }
}