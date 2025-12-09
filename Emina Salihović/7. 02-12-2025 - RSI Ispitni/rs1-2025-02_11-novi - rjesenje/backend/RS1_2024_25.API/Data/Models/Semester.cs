using RS1_2024_25.API.Data.Models.SharedTables;
using RS1_2024_25.API.Data.Models.TenantSpecificTables.Modul1_Auth;
using RS1_2024_25.API.Data.Models.TenantSpecificTables.Modul2_Basic;
using RS1_2024_25.API.Helper.BaseClasses;
using System.ComponentModel.DataAnnotations.Schema;

namespace RS1_2024_25.API.Data.Models
{
    public class Semester : BaseEntity
    {
        //• akademska godina: FK na tabelu AkademskaGodina(prikazati unutar combobox-a)


        public int AcademicYearId { get; set; }
        [ForeignKey(nameof(AcademicYearId))]
        public AcademicYear? AcademicYear { get; set; }


        public int StudentId { get; set; }
        [ForeignKey(nameof(StudentId))]
        public Student? Student { get; set; }


        public int RecordedById { get; set; }
        [ForeignKey(nameof(RecordedById))]
        public MyAppUser? RecordedBy { get; set; }


        //• datum upisa: DateTime
        //• godina studija: int
        //• cijena školarine: float 
        //• obnova: bool 

        public DateTime DateOfEnrollment { get; set; }
        public int YearOfStudy { get; set; }
        public float Price { get; set; }
        public bool Renewal { get; set; }

    }
}
