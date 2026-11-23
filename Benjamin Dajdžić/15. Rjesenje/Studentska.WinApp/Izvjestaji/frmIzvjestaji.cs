using Microsoft.Reporting.WinForms;
using Studentska.Data.Entiteti;
using Studentska.Servis.Servisi;
using System.Data;

namespace Studentska.WinApp.Izvjestaji
{
    public partial class frmIzvjestaji : Form
    {
        private Student? student;
        StudentiKnjigeServis studentiKnjigeServis = new StudentiKnjigeServis();

        //public frmIzvjestaji()
        //{
        //    InitializeComponent();
        //    reportViewer1.LocalReport.ReportEmbeddedResource =
        //        "Studentska.WinApp.Izvjestaji.rptStudentiUplate.rdlc";
        //}

        public frmIzvjestaji(Student? student)
        {
            InitializeComponent();

            reportViewer1.LocalReport.ReportEmbeddedResource =
                "Studentska.WinApp.Izvjestaji.rptStudentiUplate.rdlc";

            this.student = student;
        }

        private void frmIzvjestaji_Load(object sender, EventArgs e)
        {

            UcitajReport();

            reportViewer1.RefreshReport();
        }

        private void UcitajReport()
        {

            // 1. TABELA

            var iznajmljivanjaStudenta = studentiKnjigeServis
                .GetAllIncluded()
                .Where(x => x.StudentId == student.Id)
                .ToList();


            var tblIznajmljivanja = new dsIzvjestaji.dsIznajmljivanjaDataTable();

            var ukupno = 0;

            for (int i = 0; i < iznajmljivanjaStudenta.Count(); i++)
            {

                var red = tblIznajmljivanja.NewdsIznajmljivanjaRow();

                red.Rb = (i + 1).ToString();
                red.Knjiga = iznajmljivanjaStudenta[i]?.Knjiga.ToString() ?? "N/A";
                red.Vracena = iznajmljivanjaStudenta[i].Vracena ? "Da" : "Ne";


                var datumIznajmljivanja = iznajmljivanjaStudenta[i].DatumIznajmljivanja;

                var datumKraja = iznajmljivanjaStudenta[i]?.DatumVracanja ?? DateTime.Now;

                var brojDana = (datumKraja - datumIznajmljivanja).Days + 1;

                red.BrojDana = brojDana.ToString();

                ukupno += brojDana;

                tblIznajmljivanja.Rows.Add(red);

            }

            var rds = new ReportDataSource();

            rds.Value = tblIznajmljivanja;
            rds.Name = "dsIznajmljivanja";

            reportViewer1.LocalReport.DataSources.Add(rds);


            // 2. CUSTOM PARAMETRI 

            var rpc = new ReportParameterCollection();

            rpc.Add(new ReportParameter("student", student.ToString()));
            rpc.Add(new ReportParameter("brojDana",ukupno.ToString()));

            reportViewer1.LocalReport.SetParameters(rpc);


        }
    }
}
