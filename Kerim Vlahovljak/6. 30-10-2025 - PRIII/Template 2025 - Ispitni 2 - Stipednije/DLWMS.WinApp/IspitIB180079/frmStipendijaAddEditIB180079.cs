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

            var godina = cbGodina?.SelectedItem?.ToString() ?? "2025"; // "2025" , "2024"


            cbStipendijaGodina.DataSource = db.StipendijeGodineIB180079
                .Include(x => x.Stipendija)
                .Where(x => x.Godina == godina)
                .ToList();


        }

        private void btnSacuvaj_Click(object sender, EventArgs e)
        {

            if (ValidirajUnos())
            {

                var odabraniStudent = cbStudent.SelectedItem as Student;

                var odabranaStipendijaGodina = cbStipendijaGodina.SelectedItem as StipendijeGodineIB180079;


                //var novaStudentStipenija = new StudentiStipendijeIB180079()
                //{
                //    //Id = 1, // PROGRAM PUCA
                //    //Student = odabraniStudent,
                //    StudentId = odabraniStudent.Id,
                //    StipendijaGodinaId = odabranaStipendijaGodina.Id

                //};


                if (db.StudentiStipendijeIB180079.ToList()
                    .Exists(x => x.StudentId == odabraniStudent.Id 
                    && x.StipendijaGodinaId == odabranaStipendijaGodina.Id))
                {

                    MessageBox.Show($"Student {odabraniStudent} već ima odabranu stipendiju {odabranaStipendijaGodina}","Upozorenje",MessageBoxButtons.OK,MessageBoxIcon.Warning);

                }
                else
                {
                    var novaStudentStipenija = new StudentiStipendijeIB180079();

                    novaStudentStipenija.StudentId = odabraniStudent.Id;
                    novaStudentStipenija.StipendijaGodinaId = odabranaStipendijaGodina.Id;


                    db.StudentiStipendijeIB180079.Add(novaStudentStipenija);

                    db.SaveChanges();

                    DialogResult = DialogResult.OK;

                }




            }


        }


        private bool ValidirajUnos()
        {
            return Helpers.Validator.ProvjeriUnos(cbStipendijaGodina, err, Kljucevi.RequiredField);
        }
    }
}
