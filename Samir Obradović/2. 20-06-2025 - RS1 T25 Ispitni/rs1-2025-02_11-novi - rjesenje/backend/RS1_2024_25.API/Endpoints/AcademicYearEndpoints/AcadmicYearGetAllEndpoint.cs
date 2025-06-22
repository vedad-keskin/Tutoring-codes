using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RS1_2024_25.API.Data;
using RS1_2024_25.API.Helper.Api;
using static RS1_2024_25.API.Endpoints.CityEndpoints.AcadmicYearGetAllEndpoint;
using static RS1_2024_25.API.Endpoints.CityEndpoints.CityGetAll1Endpoint;

namespace RS1_2024_25.API.Endpoints.CityEndpoints;

//bez paging i bez filtera
[Route("academicYears")]
public class AcadmicYearGetAllEndpoint(ApplicationDbContext db) : MyEndpointBaseAsync
    .WithoutRequest
    .WithResult<AcadmicYearGetAllResponse[]>
{
    [HttpGet("all")]
    public override async Task<AcadmicYearGetAllResponse[]> HandleAsync(CancellationToken cancellationToken = default)
    {
        var result = await db.AcademicYears
                        .Select(c => new AcadmicYearGetAllResponse
                        {
                            ID = c.ID,
                            Name = $"{c.StartDate.Year}-{c.EndDate.Year % 100}"
                        })
                        .ToArrayAsync(cancellationToken);

        return result;
    }

    public class AcadmicYearGetAllResponse
    {
        public required int ID { get; set; }
        public required string Name { get; set; }
    }
}