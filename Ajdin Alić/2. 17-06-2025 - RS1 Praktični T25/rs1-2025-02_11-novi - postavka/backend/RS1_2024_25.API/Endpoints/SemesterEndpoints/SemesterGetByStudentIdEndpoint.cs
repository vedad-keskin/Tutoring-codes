using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RS1_2024_25.API.Data;
using RS1_2024_25.API.Data.Models.SharedTables;
using RS1_2024_25.API.Data.Models.TenantSpecificTables.Modul1_Auth;
using RS1_2024_25.API.Helper.Api;
using static RS1_2024_25.API.Endpoints.CityEndpoints.CityGetAll1Endpoint;
using static RS1_2024_25.API.Endpoints.CityEndpoints.SemesterGetByStudentIdEndpoint;

namespace RS1_2024_25.API.Endpoints.CityEndpoints;

[Route("semesters")]
public class SemesterGetByStudentIdEndpoint(ApplicationDbContext db) : MyEndpointBaseAsync
    .WithRequest<int>
    .WithResult<SemesterGetByStudentIdResponse[]>
{
    [HttpGet("{id}")]
    public override async Task<SemesterGetByStudentIdResponse[]> HandleAsync(int id, CancellationToken cancellationToken = default)
    {
        var result = await db.Semesters
            .Where(x=> x.StudentId == id)
            .Include(x=> x.AcademicYear)
            .Include(x=> x.RecordedBy)
                        .Select(c => new SemesterGetByStudentIdResponse
                        {
                            ID = c.ID,
                            //                                        2024-25
                            AcademicYearName = $"{c.AcademicYear.StartDate.Year}-{c.AcademicYear.EndDate.Year}",
                            StudyYear = c.StudyYear,
                            Renewal = c.Renewal,
                            DateOfEnrollment = c.DateOfEnrollment,
                            RecordedByName = c.RecordedBy.FirstName
                        })
                        .ToArrayAsync(cancellationToken);

        return result;
    }

    public class SemesterGetByStudentIdResponse
    {
        public required int ID { get; set; }
        public string AcademicYearName { get; set; }
        public int StudyYear { get; set; }
        public bool Renewal { get; set; }
        public DateTime DateOfEnrollment { get; set; }
        public string RecordedByName { get; set; } 

    }
}