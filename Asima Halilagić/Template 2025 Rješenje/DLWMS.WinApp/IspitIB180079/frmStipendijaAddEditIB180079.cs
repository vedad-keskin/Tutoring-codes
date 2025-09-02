using DLWMS.Data;
using DLWMS.Data.IspitIB180079;
using DLWMS.Infrastructure;
using DLWMS.WinApp.Helpers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
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
        private StudentiStipendijeIB180079? odabranaStudentStipendija;

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

                cbGodina.SelectedItem = odabranaStudentStipendija.StipendijaGodina.Godina;

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

            var odabranaGodina = cbGodina.SelectedItem?.ToString() ?? "";

            cbStipendijaGodina.DataSource = db.StipendijeGodineIB180079
                .Include(x => x.Stipendija)
                .Where(x => x.Godina == odabranaGodina)
                .ToList();

            //cbStipendijaGodina.DisplayMember = "Stipendija";

        }

        private void btnSacuvaj_Click(object sender, EventArgs e)
        {
            if (Validiraj())
            {

                var odabraniStudent = cbStudent.SelectedItem as Student;
                var odabranaStipendijaGodina = cbStipendijaGodina.SelectedItem as StipendijeGodineIB180079;

                if (db.StudentiStipendijeIB180079.ToList().Exists(x => x.StudentId == odabraniStudent.Id && x.StipendijaGodinaId == odabranaStipendijaGodina.Id))
                {

                    MessageBox.Show($"Student {odabraniStudent} već ima evidentiranu stipediju {odabranaStipendijaGodina} na kalendarskoj {odabranaStipendijaGodina.Godina}", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
                if (odabranaStudentStipendija != null) // editovanje 
                {

                    var untrackedStudentStipendija = db.StudentiStipendijeIB180079
                        .First(x => x.Id == odabranaStudentStipendija.Id);

                    untrackedStudentStipendija.StipendijaGodinaId = odabranaStipendijaGodina.Id;


                    db.StudentiStipendijeIB180079.Update(untrackedStudentStipendija);

                }
                else
                {
                    var novaStudentStipendija = new StudentiStipendijeIB180079()
                    {
                        StudentId = odabraniStudent!.Id,
                        StipendijaGodinaId = odabranaStipendijaGodina!.Id

                    };

                    db.StudentiStipendijeIB180079.Add(novaStudentStipendija);


                }
                db.SaveChanges();

                DialogResult = DialogResult.OK;

            }
        }

        private bool Validiraj()
        {
            return Helpers.Validator.ProvjeriUnos(cbStipendijaGodina, err, Kljucevi.RequiredField);
        }
    }
}
