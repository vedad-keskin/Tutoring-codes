﻿using DLWMS.Data;
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
            var odabranaGodina = cbGodina.SelectedItem.ToString();


            cbStipendijeGodine.DataSource = db.StipendijeGodineIB180079
                .Where(x => x.Godina == odabranaGodina)
                .Include(x => x.Stipendija)
                .ToList();

        }

        private void btnSacuvaj_Click(object sender, EventArgs e)
        {
            if (Validiraj())
            {

                var odabraniStudent = cbStudent.SelectedItem as Student;
                var odabranaStipendijaGodina = cbStipendijeGodine.SelectedItem as StipendijeGodineIB180079;


                if (db.StudentiStipendijeIB180079.ToList().Exists(x=> x.StudentId == odabraniStudent.Id && x.StipendijaGodinaId == odabranaStipendijaGodina.Id ))
                {
                    MessageBox.Show($"Student već ima evidentiranu odabranu stipendiju {odabranaStipendijaGodina}","Upozorenje",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                }
                else
                {

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
        }

        private bool Validiraj()
        {
            return Helpers.Validator.ProvjeriUnos(cbStipendijeGodine, err, Kljucevi.RequiredField);
        }
    }
}
