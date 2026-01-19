using RS1_2024_25.API.Data.Models.SharedTables;
using RS1_2024_25.API.Data.Models.TenantSpecificTables.Modul1_Auth;
using RS1_2024_25.API.Data.Models.TenantSpecificTables.Modul2_Basic;
using RS1_2024_25.API.Helper.BaseClasses;
using System.ComponentModel.DataAnnotations.Schema;

namespace RS1_2024_25.API.Data.Models
{
    public class Semester : BaseEntity
    {

        //• datum upisa: DateTime
        //• godina studija: int
        //• cijena školarine: float 
        //• obnova: bool 

        public DateTime WinterSemester { get; set; }
        public int YearOfStudy { get; set; }
        public float Price { get; set; }
        public bool Renewal { get; set; }


        //• akademska godina: FK na tabelu AkademskaGodina

        public int AcademicYearId { get; set; } 
        [ForeignKey(nameof(AcademicYearId))]
        public AcademicYear? AcademicYear { get; set; }


        // FK na STUDENT

        public int StudentId { get; set; }
        [ForeignKey(nameof(StudentId))]
        public Student? Student { get; set; }

        // FK na osobu koja je evidentirala zapis u sistem
        public int RecordedById { get; set; }
        [ForeignKey(nameof(RecordedById))]
        public MyAppUser? RecordedBy { get; set; }

    }
}
