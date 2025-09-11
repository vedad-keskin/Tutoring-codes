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
    public partial class frmStipendijeIB180079 : Form
    {
        DLWMSContext db = new DLWMSContext();
        public frmStipendijeIB180079()
        {
            InitializeComponent();
        }

        private void frmStipendijeIB180079_Load(object sender, EventArgs e)
        {
            dgvStipendijeGodine.AutoGenerateColumns = false;

            UcitajComboBox();

            UcitajStipendijeGodine();

        }

        private void UcitajStipendijeGodine()
        {

            var stipendijeGodine = db.StipendijeGodineIB180079
                .Include(x => x.Stipendija)
                .ToList();

            if (stipendijeGodine != null)
            {

                dgvStipendijeGodine.DataSource = null;
                dgvStipendijeGodine.DataSource = stipendijeGodine;

            }



        }

        private void UcitajComboBox()
        {

            cbGodina.SelectedIndex = 0;

            cbStipendija.DataSource = db.StipendijeIB180079.ToList();

        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            if (Validiraj())
            {

                var godina = cbGodina.SelectedItem.ToString();

                var stipendija = cbStipendija.SelectedItem as StipendijeIB180079;

                var iznos = int.Parse(txtIznos.Text);

                if (db.StipendijeGodineIB180079.ToList().Exists(x => x.Godina == godina && x.StipendijaId == stipendija.Id))
                {

                    MessageBox.Show($"Već postoji odabrana stipendija {stipendija} na godini {godina}", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
                else
                {

                    var novaStipendijaGodina = new StipendijeGodineIB180079()
                    {

                        Godina = godina,
                        StipendijaId = stipendija.Id,
                        Iznos = iznos,
                        Aktivan = true

                    };

                    db.StipendijeGodineIB180079.Add(novaStipendijaGodina);
                    db.SaveChanges();

                    txtIznos.Clear();

                    UcitajStipendijeGodine();


                }



            }
        }

        private bool Validiraj()
        {
            return Validator.ProvjeriUnos(txtIznos, err, Kljucevi.RequiredField);
        }

        private void dgvStipendijeGodine_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            var odabranaStipendijaGodina = dgvStipendijeGodine.SelectedRows[0].DataBoundItem as StipendijeGodineIB180079;

            odabranaStipendijaGodina.Aktivan = !odabranaStipendijaGodina.Aktivan;

            db.StipendijeGodineIB180079.Update(odabranaStipendijaGodina);
            db.SaveChanges();

            UcitajStipendijeGodine();


        }

        private async void btnGenerisi_Click(object sender, EventArgs e)
        {
            // 1. dio
            // -- validacije
            // -- thread <--> await/async/Task
            // -- ovdje radimo combo box ako ga ima

            //Thread thread = new Thread(() => GenerisiStipendije());
            //thread.Start();

            await Task.Run(() => GenerisiStipendije());


        }

        private void GenerisiStipendije()
        {

            // 2. dio
            // -- pohrane
            // -- kalkulacije
            // -- sleep

            var odabranaStipendijaGodina = dgvStipendijeGodine.SelectedRows[0].DataBoundItem as StipendijeGodineIB180079;

            var sviStudenti = db.Studenti.ToList();

            var info = "";

            var redniBroj = 1;


            for (int i = 0; i < sviStudenti.Count(); i++)
            {

                if (!db.StudentiStipendijeIB180079.ToList().Exists(x => x.StipendijaGodinaId == odabranaStipendijaGodina.Id && x.StudentId == sviStudenti[i].Id))
                {

                    Thread.Sleep(300);

                    var novaStudentStipendija = new StudentiStipendijeIB180079()
                    {

                        StudentId = sviStudenti[i].Id,
                        StipendijaGodinaId = odabranaStipendijaGodina.Id

                    };

                    info += $"{redniBroj}. {odabranaStipendijaGodina} stipendija u iznosu od {odabranaStipendijaGodina.Iznos} dodata {sviStudenti[i]}{Environment.NewLine}";

                    redniBroj++;

                    db.StudentiStipendijeIB180079.Add(novaStudentStipendija);
                    db.SaveChanges();



                }

            }





            Action action = () =>
            {
                // 3. dio
                // -- mbox  
                // -- ucitavanja
                // -- info

                MessageBox.Show("Uspješno su generisane stipendije", "Informacija", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtInfo.Text = info;


            };
            BeginInvoke(action);


        }

        private void frmStipendijeIB180079_FormClosed(object sender, FormClosedEventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}
