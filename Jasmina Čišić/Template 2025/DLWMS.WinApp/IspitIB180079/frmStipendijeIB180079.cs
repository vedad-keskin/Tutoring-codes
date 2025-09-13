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

        private void UcitajComboBox()
        {

            cbGodina.SelectedIndex = 0;

            cbStipendija.DataSource = db.StipendijeIB180079.ToList();

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

        private void btnDodaj_Click(object sender, EventArgs e)
        {

            if (Validiraj())
            {

                var godina = cbGodina.SelectedItem.ToString();

                var stipendija = cbStipendija.SelectedItem as StipendijeIB180079;

                // STRING -> INT 
                var iznos = int.Parse(txtIznos.Text);

                if (db.StipendijeGodineIB180079.ToList().Exists(x => x.Godina == godina && x.StipendijaId == stipendija.Id))
                {
                    MessageBox.Show($"Odabrana stipendija {stipendija} je već evidentrana na {godina} godini", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {

                    var novaStipendijaGodina = new StipendijeGodineIB180079()
                    {

                        StipendijaId = stipendija.Id,
                        Godina = godina,
                        Iznos = iznos,
                        Aktivan = true

                    };

                    db.StipendijeGodineIB180079.Add(novaStipendijaGodina);
                    db.SaveChanges();

                    UcitajStipendijeGodine();

                    txtIznos.Clear();



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
            // -- thread
            // -- validacije
            // -- sve sto je vezano za combo box 


            await Task.Run(() => GenerisiStipendije());



        }

        private void GenerisiStipendije()
        {

            // 2. dio
            // -- pohrane
            // -- kalkuacije
            // -- sleep

            var odabranaStipendijaGodina = dgvStipendijeGodine.SelectedRows[0].DataBoundItem as StipendijeGodineIB180079;


            var sviStudenti = db.Studenti.ToList();

            var info = "";

            var redniBroj = 1;

            for (int i = 0; i < sviStudenti.Count(); i++)
            {

                if (!db.StudentiStipendijeIB180079.ToList().Exists(x =>
                x.StudentId == sviStudenti[i].Id
                && x.StipendijaGodinaId == odabranaStipendijaGodina.Id))
                {

                    var novaStudentStipendija = new StudentiStipendijeIB180079()
                    {

                        StudentId = sviStudenti[i].Id,
                        StipendijaGodinaId = odabranaStipendijaGodina.Id

                    };

                    info += $"{redniBroj}. {odabranaStipendijaGodina} stipendija u iznosu od {odabranaStipendijaGodina.Iznos} dodata {sviStudenti[i]}{Environment.NewLine}";

                    redniBroj++;

                    db.StudentiStipendijeIB180079.Add(novaStudentStipendija);
                    db.SaveChanges();

                    Thread.Sleep(300);



                }


            }




            Action action = () =>
            {
                // 3. dio
                // -- mbox
                // -- info
                // -- ucitavanja

                MessageBox.Show($"Generisanje je usješno izvršeno", "Informacija", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
