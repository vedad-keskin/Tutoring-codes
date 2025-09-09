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
            cbGodina.SelectedIndex = 0;

            cbStudent.DataSource = db.Studenti.ToList();

        }

        private void cbGodina_SelectedIndexChanged(object sender, EventArgs e)
        {
            var godina = cbGodina?.SelectedItem?.ToString() ?? "";

            cbStipendijaGodina.DataSource = db.StipendijeGodineIB180079
                .Include(x => x.Stipendija)
                .Where(x => x.Godina == godina)
                .ToList();




        }

        private void btnSacuvaj_Click(object sender, EventArgs e)
        {

            if (Validiraj())
            {

                var student = cbStudent.SelectedItem as Student;

                var stipendijaGodina = cbStipendijaGodina.SelectedItem as StipendijeGodineIB180079;

                if (db.StudentiStipendijeIB180079.ToList()
                    .Exists(x => x.StudentId == student.Id 
                    && x.StipendijaGodinaId == stipendijaGodina.Id))
                {
                    MessageBox.Show($"Student {student} već ima evidentiranu stipedniju {stipendijaGodina}","Upozorenje",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                }
                else
                {
                    var novaStudentStipendija = new StudentiStipendijeIB180079()
                    {
                   
                        StudentId = student.Id,
                        StipendijaGodinaId = stipendijaGodina.Id
                   
                    };

                    db.StudentiStipendijeIB180079.Add(novaStudentStipendija);
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
