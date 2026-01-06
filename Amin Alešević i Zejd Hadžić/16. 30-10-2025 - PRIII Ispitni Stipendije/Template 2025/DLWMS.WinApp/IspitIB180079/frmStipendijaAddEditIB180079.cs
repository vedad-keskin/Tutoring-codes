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
        private StudentiStipendijeIB180079? odabranaStudentStipendija; // ostaje null kod dodavanje

        public frmStipendijaAddEditIB180079()
        {
            InitializeComponent();
        }

        public frmStipendijaAddEditIB180079(StudentiStipendijeIB180079? odabranaStudentStipendija)
        {
            InitializeComponent();
            this.odabranaStudentStipendija = odabranaStudentStipendija;
        }

        private void frmStipendijaAddEditIB180079_Load(object sender, EventArgs e)
        {
            UcitajComboBox();

            UcitajInfo();
        }

        private void UcitajInfo()
        {
            if(odabranaStudentStipendija != null)
            {

                 cbStudent.SelectedIndex = db.Studenti.ToList().FindIndex(x => x.Id == odabranaStudentStipendija.StudentId);

                cbStudent.Enabled = false;

                cbGodina.SelectedItem = odabranaStudentStipendija.GodinaInfo;

                cbStipendijaGodina.SelectedIndex = db.StipendijeGodineIB180079.ToList().FindIndex(x => x.StipendijaId == odabranaStudentStipendija.StipendijaGodina.StipendijaId);


            }


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




            //var novaStudentStipendija = new StudentiStipendijeIB180079()
            //{
            //    //Id = 1, // PUCA KOD
            //    //Student = odabraniStudent, PUCA KOD

            //    StudentId = odabraniStudent.Id,
            //    StipendijaGodinaId = odabranaStipendijaGodina.Id


            //};

            var odabraniStudent = cbStudent.SelectedItem as Student;

            var odabranaStipendijaGodina = cbStipendijaGodina.SelectedItem as StipendijeGodineIB180079;

            if (db.StudentiStipendijeIB180079.ToList()
                .Exists(x => x.StudentId == odabraniStudent.Id 
                && x.StipendijaGodinaId == odabranaStipendijaGodina.Id))
            {
                MessageBox.Show($"Student {odabraniStudent} već ima stipendiju {odabranaStipendijaGodina}","Upozorenje",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
            else if (odabranaStudentStipendija != null) // editovanje
            {

                // nema nista dodatno includano
                var detachedStudentStipendija = db.StudentiStipendijeIB180079.First(x => x.Id == odabranaStudentStipendija.Id);

                //odabranaStudentStipendija.StudentId = odabraniStudent.Id;

                //odabranaStudentStipendija.StipendijaGodinaId = odabranaStipendijaGodina.Id;

                detachedStudentStipendija.StipendijaGodinaId = odabranaStipendijaGodina.Id;

                db.StudentiStipendijeIB180079.Update(detachedStudentStipendija);

                db.SaveChanges();

                DialogResult = DialogResult.OK;


            }
            else // dodavanje
            {

                var novaStudentStipendija = new StudentiStipendijeIB180079();

                novaStudentStipendija.StudentId = odabraniStudent.Id;
                novaStudentStipendija.StipendijaGodinaId = odabranaStipendijaGodina.Id;

                db.StudentiStipendijeIB180079.Add(novaStudentStipendija);
                db.SaveChanges();

                DialogResult = DialogResult.OK;


            }




        }
    }
}
