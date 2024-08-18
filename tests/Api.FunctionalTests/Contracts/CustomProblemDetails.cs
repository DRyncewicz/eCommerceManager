using SharedKernel;

namespace Api.FunctionalTests.Contracts;

public class ProblemDetailsResponse
{
    public string Type { get; set; }
    public string Title { get; set; }
    public int? Status { get; set; }
    public string Detail { get; set; }
    public ErrorsContainer Errors { get; set; }
}

public class ErrorsContainer
{
    public List<Error> Errors { get; set; }
}