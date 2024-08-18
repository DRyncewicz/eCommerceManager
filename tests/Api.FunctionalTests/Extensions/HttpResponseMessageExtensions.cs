using Api.FunctionalTests.Contracts;
using SharedKernel;
using System.Net.Http.Json;

namespace Api.FunctionalTests.Extensions;

internal static class HttpResponseMessageExtensions
{
    internal static async Task<ProblemDetailsResponse> GetProblemDetails(
        this HttpResponseMessage response)
    {
        if (response.IsSuccessStatusCode)
        {
            throw new InvalidOperationException("Successful response");
        }

        var problemDetailsResponse = await response
            .Content
            .ReadFromJsonAsync<ProblemDetailsResponse>();

        Ensure.NotNull(problemDetailsResponse);

        return problemDetailsResponse;
    }
}