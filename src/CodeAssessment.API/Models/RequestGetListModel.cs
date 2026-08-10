using Humanizer;

namespace CodeAssessment.API.Models;

public class RequestGetListModel
{
    public int? Page { get; set; }
    public int? Size { get; set; }
}