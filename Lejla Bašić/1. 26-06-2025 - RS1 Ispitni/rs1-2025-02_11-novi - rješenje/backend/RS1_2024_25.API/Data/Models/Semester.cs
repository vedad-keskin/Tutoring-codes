using RS1_2024_25.API.Data.Models.SharedTables;
using RS1_2024_25.API.Data.Models.TenantSpecificTables.Modul1_Auth;
using RS1_2024_25.API.Data.Models.TenantSpecificTables.Modul2_Basic;
using RS1_2024_25.API.Helper.BaseClasses;
using System.ComponentModel.DataAnnotations.Schema;

namespace RS1_2024_25.API.Data.Models
{
    public class Semester : BaseEntity // vec dodan PK 
    {

        //• akademska godina: FK na tabelu AkademskaGodina(prikazati unutar combobox-a)

        public int AcademicYearId { get; set; } // FK na AG
        [ForeignKey(nameof(AcademicYearId))]
        public AcademicYear? AcademicYear { get; set; } // Navigaciona veza na AG

        // FK na Student

        public int StudentId { get; set; } // FK na Student
        [ForeignKey(nameof(StudentId))]
        public Student? Student { get; set; } // Navigaciona veza na Student

        // FK na osobu koja je evidentirala semestar u sistem

        public int RecordedById { get; set; } // FK na RecordedBy
        [ForeignKey(nameof(RecordedById))]
        public MyAppUser? RecordedBy { get; set; } // Navigaciona veza na RecordedBy

        //• datum upisa: DateTime
        //• godina studija: int
        //• cijena školarine: float 
        //• obnova: bool

        public DateTime DateOfEnrollemnt { get; set; }
        public int StudyYear { get; set; }
        public float Price { get; set; }
        public bool Renewal { get; set; }


    }
}
