using DLWMS.Data;
using DLWMS.Data.IspitIB180079;
using DLWMS.Infrastructure;
using DocumentFormat.OpenXml.Vml.Spreadsheet;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DLWMS.WinApp.IspitIB180079
{
    public partial class frmStipendijaAddEditIB180079 : Form
    {
        DLWMSContext db = new DLWMSContext();
        public frmStipendijaAddEditIB180079()
        {
            InitializeComponent();
        }

        private void frmStipendijaAddEditIB180079_Load(object sender, EventArgs e)
        {
            UcitajComboBox();
        }

        private void UcitajComboBox()
        {
            cbStudent.DataSource = db.Studenti.ToList();

            cbGodina.SelectedIndex = 0;

        }

        private void cbGodina_SelectedIndexChanged(object sender, EventArgs e)
        {
            var odabranaGodina = cbGodina?.SelectedItem?.ToString() ?? "2025"; // "2025" "2024"


            cbStipendijaGodina.DataSource = db.StipendijeGodineIB180079
                .Where(x => x.Godina == odabranaGodina)
                .Include(x => x.Stipendija)
                .ToList();


        }

        private void btnSacuvaj_Click(object sender, EventArgs e)
        {


            var odabraniStudent = cbStudent.SelectedItem as Student;

            var odabranaStipendijaGodina = cbStipendijaGodina.SelectedItem as StipendijeGodineIB180079;


            //var novaStudentStipendija = new StudentiStipendijeIB180079()
            //{
            //    //Id = 1, // PUCA KOD
            //    //Student = odabraniStudent, PUCA KOD

            //    StudentId = odabraniStudent.Id,
            //    StipendijaGodinaId = odabranaStipendijaGodina.Id


            //};

            var novaStudentStipendija = new StudentiStipendijeIB180079();

            novaStudentStipendija.StudentId = odabraniStudent.Id;
            novaStudentStipendija.StipendijaGodinaId = odabranaStipendijaGodina.Id;

            db.StudentiStipendijeIB180079.Add(novaStudentStipendija);
            db.SaveChanges();

            DialogResult = DialogResult.OK;


        }
    }
}
