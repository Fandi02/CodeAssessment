namespace CodeAssessment.API.Models;

public class RequestSaveModel
{
    public List<decimal> Plan { get; set; }
    public Guid RequestCode { get; set; }
}