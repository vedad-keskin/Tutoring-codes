using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RS1_2024_25.API.Data;
using RS1_2024_25.API.Helper.Api;
using static RS1_2024_25.API.Endpoints.CityEndpoints.AcademicYearGetAllEndpoint;
using static RS1_2024_25.API.Endpoints.CityEndpoints.CityGetAll1Endpoint;

namespace RS1_2024_25.API.Endpoints.CityEndpoints;

//bez paging i bez filtera
[Route("academicYear")]
public class AcademicYearGetAllEndpoint(ApplicationDbContext db) : MyEndpointBaseAsync
    .WithoutRequest
    .WithResult<AcademicYearGetAllResponse[]>
{
    [HttpGet("all")]
    public override async Task<AcademicYearGetAllResponse[]> HandleAsync(CancellationToken cancellationToken = default)
    {
        var result = await db.AcademicYears
                        .Select(c => new AcademicYearGetAllResponse
                        {
                            ID = c.ID,
                            Name = $"{c.StartDate.Year}-{c.EndDate.Year}"
                        })
                        .ToArrayAsync(cancellationToken);

        return result;
    }

    public class AcademicYearGetAllResponse
    {
        public required int ID { get; set; }
        public required string Name { get; set; }
    }
}