using Causely.Application.LogService.Commands.Ingest;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Causely.Web.Endpoints;

public class Logs : IEndpointGroup
{
    public static string? RoutePrefix => "/api/logs";

    public static void Map(RouteGroupBuilder groupBuilder)
    {
        groupBuilder.MapPost(IngestLogs, "ingest");
    }

    [EndpointSummary("Ingest Logs")]
    [EndpointDescription("Accepts a batch of log items and returns the accepted count.")]
    public static async Task<Ok<IngestLogResponse>> IngestLogs(ISender sender, IngestLogRequest request)
    {
        var response = await sender.Send(request);

        return TypedResults.Ok(response);
    }
}
