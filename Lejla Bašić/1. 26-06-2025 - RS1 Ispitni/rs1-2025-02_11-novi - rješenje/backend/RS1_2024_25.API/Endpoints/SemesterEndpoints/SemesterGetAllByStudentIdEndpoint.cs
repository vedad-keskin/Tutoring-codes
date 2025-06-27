using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RS1_2024_25.API.Data;
using RS1_2024_25.API.Data.Models.SharedTables;
using RS1_2024_25.API.Data.Models.TenantSpecificTables.Modul1_Auth;
using RS1_2024_25.API.Helper.Api;
using static RS1_2024_25.API.Endpoints.CityEndpoints.CityGetAll1Endpoint;
using static RS1_2024_25.API.Endpoints.CityEndpoints.SemesterGetAllByStudentIdEndpoint;

namespace RS1_2024_25.API.Endpoints.CityEndpoints;

//bez paging i bez filtera
[Route("semesters")]
public class SemesterGetAllByStudentIdEndpoint(ApplicationDbContext db) : MyEndpointBaseAsync
    .WithRequest<int>
    .WithResult<SemesterGetAllByStudentIdResponse[]>
{
    [HttpGet("{id}")]
    public override async Task<SemesterGetAllByStudentIdResponse[]> HandleAsync(int id,CancellationToken cancellationToken = default)
    {
        var result = await db.Semesters
            .Where(x=> x.StudentId == id)
                        .Select(c => new SemesterGetAllByStudentIdResponse
                        {
                            ID = c.ID,
                            AcademicYearName = $"{c.AcademicYear.StartDate.Year}-{c.AcademicYear.EndDate.Year % 100}",
                            StudyYear = c.StudyYear,
                            Renewal = c.Renewal,
                            DateOfEnrollemnt = c.DateOfEnrollemnt,
                            RecordedByName = c.RecordedBy.Email,

                        })
                        .ToArrayAsync(cancellationToken);

        return result;
    }

    public class SemesterGetAllByStudentIdResponse
    {
        public required int ID { get; set; }
        public string AcademicYearName { get; set; }
        public int StudyYear { get; set; }
        public bool Renewal { get; set; }
        public DateTime DateOfEnrollemnt { get; set; }
        public string RecordedByName { get; set; }


    }
}