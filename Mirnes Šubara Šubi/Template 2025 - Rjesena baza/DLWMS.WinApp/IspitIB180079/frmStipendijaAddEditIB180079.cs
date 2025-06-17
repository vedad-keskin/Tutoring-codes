using DLWMS.Data;
using DLWMS.Data.IspitIB180079;
using DLWMS.Infrastructure;
using DLWMS.WinApp.Helpers;
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
        private StudentiStipendijeIB180079 odabranaStudentStipendija;

        // za dodavanje nove sti.
        public frmStipendijaAddEditIB180079()
        {
            InitializeComponent();
        }

        // za edit stipendije . 
        public frmStipendijaAddEditIB180079(StudentiStipendijeIB180079 odabranaStudentStipendija)
        {
            InitializeComponent();
            this.odabranaStudentStipendija = odabranaStudentStipendija;
        }

        private void frmStipendijaAddEditIB180079_Load(object sender, EventArgs e)
        {
            UcitajComboBox();
        }

        private void UcitajComboBox()
        {
            cbStudent.DataSource = db.Studenti.ToList();


            if(odabranaStudentStipendija == null) // add
            {
                cbGodina.SelectedIndex = 0;


            }
            else
            {
                cbGodina.SelectedItem = odabranaStudentStipendija.StipendijaGodina.Godina;

                cbGodina.Enabled = false;

                cbStudent.SelectedIndex = db.Studenti.ToList().FindIndex(x=> x.Id == odabranaStudentStipendija.StudentId);

                cbStudent.Enabled = false;


                cbStipendijaGodina.SelectedIndex = db.StipendijeGodineIB180079.ToList().FindIndex(x => x.StipendijaId == odabranaStudentStipendija.StipendijaGodina.StipendijaId);


            }



        }

        private void cbGodina_SelectedIndexChanged(object sender, EventArgs e)
        {
            var odabranaGodina = cbGodina.SelectedItem.ToString();

            cbStipendijaGodina.DataSource = db.StipendijeGodineIB180079
                .Include(x => x.Stipendija)
                .Where(x => x.Godina == odabranaGodina)
                .ToList();
        }

        private void btnSacuvaj_Click(object sender, EventArgs e)
        {
            if (Validiraj())
            {
                var odabraniStudent = cbStudent.SelectedItem as Student;
                var odabranaStipendijaGodina = cbStipendijaGodina.SelectedItem as StipendijeGodineIB180079;

                var student = cbStudent.SelectedItem as Student;



                if (odabranaStudentStipendija == null)
                {

                    if (db.StudentiStipendijeIB180079.Include(x=> x.StipendijaGodina).ToList().Exists(x=> x.StipendijaGodina.Godina == odabranaStipendijaGodina.Godina && x.StudentId == odabraniStudent.Id))
                    {
                        MessageBox.Show("Student ima stipendiju na toj godini","Upozorenje",MessageBoxButtons.OK,MessageBoxIcon.Warning);

                    }
                    else {

                        var novaStudentStipendija = new StudentiStipendijeIB180079()
                        {
                            StudentId = odabraniStudent.Id,
                            StipendijaGodinaId = odabranaStipendijaGodina.Id
                        };

                        db.StudentiStipendijeIB180079.Add(novaStudentStipendija);
                        db.SaveChanges();

                        DialogResult = DialogResult.OK;

                    }

                }
                else
                {

                    odabranaStudentStipendija.StipendijaGodinaId = odabranaStipendijaGodina.Id;
                    odabranaStudentStipendija.StipendijaGodina = odabranaStipendijaGodina;


                    odabranaStudentStipendija.StudentId = student.Id;
                    odabranaStudentStipendija.Student = student;


                    db.StudentiStipendijeIB180079.Update(odabranaStudentStipendija);
                    db.SaveChanges();

                    DialogResult = DialogResult.OK;


                }





            }
        }

        private bool Validiraj()
        {
            return Validator.ProvjeriUnos(cbStipendijaGodina, err, Kljucevi.RequiredField);
        }
    }
}
