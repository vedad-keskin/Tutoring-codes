using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RS1_2024_25.API.Data;
using RS1_2024_25.API.Data.Models;
using RS1_2024_25.API.Data.Models.SharedTables;
using RS1_2024_25.API.Data.Models.TenantSpecificTables.Modul1_Auth;
using RS1_2024_25.API.Data.Models.TenantSpecificTables.Modul2_Basic;
using RS1_2024_25.API.Helper.Api;
using RS1_2024_25.API.Services;
using System.ComponentModel.DataAnnotations.Schema;
using static RS1_2024_25.API.Endpoints.CityEndpoints.CityUpdateOrInsertEndpoint;
using static RS1_2024_25.API.Endpoints.CityEndpoints.SemesterUpdateOrInsertEndpoint;

namespace RS1_2024_25.API.Endpoints.CityEndpoints;

[Route("semesters")]
//[MyAuthorization(isAdmin: true, isManager: false)]
public class SemesterUpdateOrInsertEndpoint(ApplicationDbContext db) : MyEndpointBaseAsync
    .WithRequest<SemesterUpdateOrInsertRequest>
    .WithActionResult<int>
{
    [HttpPost]  // Using POST to support both create and update
    public override async Task<ActionResult<int>> HandleAsync([FromBody] SemesterUpdateOrInsertRequest request, CancellationToken cancellationToken = default)
    {

        // Check if we're performing an insert or update based on the ID value
        bool isInsert = (request.ID == null || request.ID == 0);
        Semester? semester;

        if (isInsert)
        {
            // Insert operation: create a new city entity
            semester = new Semester();
            db.Semesters.Add(semester); // Add the new city to the context
        }
        else
        {
            // Update operation: retrieve the existing city
            semester = await db.Semesters.SingleOrDefaultAsync(x => x.ID == request.ID, cancellationToken);

            if (semester == null)
            {
                return NotFound("Semester not found");
            }
        }

        // Set common properties for both insert and update operations
        semester.StudyYear = request.StudyYear;
        semester.AcademicYearId = request.AcademicYearId;
        semester.StudentId = request.StudentId;
        semester.RecordedById = request.RecordedById;
        semester.DateOfEnrollemnt = request.DateOfEnrollemnt;
        semester.Price = request.Price;
        semester.Renewal = request.Renewal;

        if(db.Semesters.Where(x=> x.StudentId == request.StudentId).ToList().Exists(x=> x.AcademicYearId == request.AcademicYearId))
        {
            return NotFound("Academic Year already in use for this student");
        }


        // Save changes to the database
        await db.SaveChangesAsync(cancellationToken);

        return Ok(semester.ID);
    }

    public class SemesterUpdateOrInsertRequest
    {
        public int? ID { get; set; } // Nullable to allow null for insert operations
        public int AcademicYearId { get; set; } // FK na AG
        public int StudentId { get; set; } // FK na Student
        public int RecordedById { get; set; } // FK na RecordedBy
        public DateTime DateOfEnrollemnt { get; set; }
        public int StudyYear { get; set; }
        public float Price { get; set; }
        public bool Renewal { get; set; }

    }
}
