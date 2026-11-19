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
            this.student = student;
            InitializeComponent();
            reportViewer1.LocalReport.ReportEmbeddedResource =
                "Studentska.WinApp.Izvjestaji.rptStudentiUplate.rdlc";
        }

        private void frmIzvjestaji_Load(object sender, EventArgs e)
        {

            UcitajIzvjestaj();

            reportViewer1.RefreshReport();
        }

        private void UcitajIzvjestaj()
        {

            // CUSTOM TABELA

            var iznajmljivanjaStudenta = studentiKnjigeServis
                .GetAllIncluded()
                .Where(x => x.StudentId == student.Id)
                .ToList();

            var tblIznajmljivanja = new dsIzvjestaji.dsIznajmljivanjaDataTable();

            var sumaDana = 0;

            for (int i = 0; i < iznajmljivanjaStudenta.Count(); i++)
            {

                var red = tblIznajmljivanja.NewdsIznajmljivanjaRow();

                red.Rb = (i + 1).ToString();
                red.Knjiga = iznajmljivanjaStudenta[i]?.Knjiga?.ToString() ?? "N/A";
                red.Vracena = iznajmljivanjaStudenta[i].Vracena ? "Da" : "Ne";

                //var datumKraja = iznajmljivanjaStudenta[i].DatumVracanja == null ? DateTime.Now : iznajmljivanjaStudenta[i].DatumVracanja;

                var datumKraja = iznajmljivanjaStudenta[i]?.DatumVracanja ?? DateTime.Now;


                //               20.11       -    10.11 = 10
                int brojDana = (datumKraja - iznajmljivanjaStudenta[i].DatumIznajmljivanja).Days + 1;

                sumaDana += brojDana;

                red.BrojDana = brojDana.ToString();

                tblIznajmljivanja.Rows.Add(red);

            }

            var rds = new ReportDataSource();

            rds.Value = tblIznajmljivanja;
            rds.Name = "dsIznajmljivanja";

            reportViewer1.LocalReport.DataSources.Add(rds);

            // CUSTOM PARAMETRI


            var rpc = new ReportParameterCollection();

            rpc.Add(new ReportParameter("student", student?.ToString() ?? "N/A"));
            rpc.Add(new ReportParameter("suma", sumaDana.ToString()    ));


            reportViewer1.LocalReport.SetParameters(rpc);

        }
    }
}
