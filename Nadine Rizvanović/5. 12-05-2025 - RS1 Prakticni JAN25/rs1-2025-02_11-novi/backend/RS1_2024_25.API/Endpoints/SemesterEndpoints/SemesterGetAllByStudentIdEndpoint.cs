using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RS1_2024_25.API.Data;
using RS1_2024_25.API.Data.Models.SharedTables;
using RS1_2024_25.API.Helper.Api;
using static RS1_2024_25.API.Endpoints.SemesterEndpoints.SemesterGetAllByStudentIdEndpoint;

namespace RS1_2024_25.API.Endpoints.SemesterEndpoints;

[Route("semesters")]
public class SemesterGetAllByStudentIdEndpoint(ApplicationDbContext db) : MyEndpointBaseAsync
    .WithRequest<int>
    .WithResult<SemesterGetAllByStudentIdResponse[]>
{
    [HttpGet("{id}")]
    public override async Task<SemesterGetAllByStudentIdResponse[]> HandleAsync(int id, CancellationToken cancellationToken = default)
    {
        var result = await db.Semesters
            .Include(x=> x.AcademicYear)
            .Include(x=> x.RecordedBy)
            .Where(x=> x.StudentId == id)
                        .Select(c => new SemesterGetAllByStudentIdResponse
                        {
                            ID = c.ID,
                            AcademicYearDescription = c.AcademicYear.Description,
                            YearOfStudy = c.YearOfStudy,
                            Renewal = c.Renewal,
                            DateOfEntrollment = c.DateOfEntrollment,
                            RecordedByName = c.RecordedBy.Email

                        })
                        .ToArrayAsync(cancellationToken);

        return result;
    }

    public class SemesterGetAllByStudentIdResponse
    {
        public int ID { get; set; }
        public string? AcademicYearDescription { get; set; }
        public int YearOfStudy { get; set; }
        public bool Renewal { get; set; }
        public DateTime DateOfEntrollment { get; set; }
        public string RecordedByName { get; set; }
    }
}
