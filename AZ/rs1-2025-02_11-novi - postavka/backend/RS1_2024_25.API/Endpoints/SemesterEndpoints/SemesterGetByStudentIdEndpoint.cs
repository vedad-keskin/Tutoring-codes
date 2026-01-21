using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RS1_2024_25.API.Data;
using RS1_2024_25.API.Data.Models.SharedTables;
using RS1_2024_25.API.Data.Models.TenantSpecificTables.Modul1_Auth;
using RS1_2024_25.API.Data.Models.TenantSpecificTables.Modul2_Basic;
using RS1_2024_25.API.Helper.Api;
using System.ComponentModel.DataAnnotations.Schema;
using static RS1_2024_25.API.Endpoints.CityEndpoints.CityGetAll1Endpoint;
using static RS1_2024_25.API.Endpoints.CityEndpoints.SemesterGetByStudentIdEndpoint;

namespace RS1_2024_25.API.Endpoints.CityEndpoints;

//bez paging i bez filtera
[Route("semesters")]
public class SemesterGetByStudentIdEndpoint(ApplicationDbContext db) : MyEndpointBaseAsync
    .WithRequest<int>
    .WithResult<SemesterGetByStudentIdResponse[]>
{
    [HttpGet("{id}")]
    public override async Task<SemesterGetByStudentIdResponse[]> HandleAsync(int id, CancellationToken cancellationToken = default)
    {
        var result = await db.Semesters
            .Where(x => x.StudentId == id)
            .Include(x => x.RecordedBy)
            .Include(x => x.AcademicYear)
                        .Select(c => new SemesterGetByStudentIdResponse
                        {
                           ID = c.ID,
                           WinterSemester = c.WinterSemester,
                           YearOfStudy = c.YearOfStudy,
                           Renewal = c.Renewal,
                           RecordedByName = c.RecordedBy.Email ,
                           AcademicYearName = $"{c.AcademicYear.StartDate.Year}-{c.AcademicYear.EndDate.Year % 100}"
                        })
                        .ToArrayAsync(cancellationToken);

        return result;
    }

    public class SemesterGetByStudentIdResponse
    {
        public required int ID { get; set; }
        public DateTime WinterSemester { get; set; }
        public int YearOfStudy { get; set; }
        public bool Renewal { get; set; }
        public string? AcademicYearName { get; set; } 
        public string? RecordedByName { get; set; } 
    }
}