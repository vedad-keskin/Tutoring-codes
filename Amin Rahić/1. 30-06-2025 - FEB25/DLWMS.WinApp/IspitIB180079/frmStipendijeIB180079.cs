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
        List<StipendijeGodineIB180079> stipendijeGodine;
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
            var aktivan = chbAktivan.Checked;


            stipendijeGodine = db.StipendijeGodineIB180079
                .Include(x => x.Stipendija)
                .Where(x=> x.Aktivan == aktivan)
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

                var iznos = int.Parse(txtIznos.Text);

                var godina = cbGodina.SelectedItem.ToString();

                var stipendija = cbStipendija.SelectedItem as StipendijeIB180079;

                if (stipendijeGodine.Exists(x => x.Godina == godina && x.StipendijaId == stipendija.Id))
                {
                    MessageBox.Show($"Već postoji stipendija {stipendija} na godini {godina}", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                }
            }
        }

        private bool Validiraj()
        {
            return Validator.ProvjeriUnos(txtIznos, err, Kljucevi.RequiredField);
        }

        private void dgvStipendijeGodine_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            var odabranaStipendijaGodina = stipendijeGodine[e.RowIndex];

            odabranaStipendijaGodina.Aktivan = !odabranaStipendijaGodina.Aktivan;

            db.StipendijeGodineIB180079.Update(odabranaStipendijaGodina);
            db.SaveChanges();

            UcitajStipendijeGodine();

        }

        private async void btnGenerisi_Click(object sender, EventArgs e)
        {
            // 1. dio 
            // -- thread --> imaju dva nacina 
            // -- validacije
            // -- sve sto je vezano za combo box 

            // 1 NACIN

            //Thread thread = new Thread(() => GenerisiStipendije());
            //thread.Start();

            // 2 NACIN 

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

            var redniBroj = 0;


            for (int i = 0; i < sviStudenti.Count(); i++)
            {

                if (!db.StudentiStipendijeIB180079.ToList().Exists(x => x.StudentId == sviStudenti[i].Id && x.StipendijaGodinaId == odabranaStipendijaGodina.Id))
                {
                    Thread.Sleep(300);

                    var novaStudentStipendija = new StudentiStipendijeIB180079()
                    {
                        StudentId = sviStudenti[i].Id,
                        StipendijaGodinaId = odabranaStipendijaGodina.Id
                    };

                    db.StudentiStipendijeIB180079.Add(novaStudentStipendija);
                    db.SaveChanges();

                    redniBroj++;

                    info += $"{redniBroj}. {odabranaStipendijaGodina} stipendija u iznosu od {odabranaStipendijaGodina.Iznos} dodata {sviStudenti[i]}{Environment.NewLine}";

                }


            }




            Action action = () =>
            {
                // 3. dio
                // -- mbox
                // -- ucitavanje 
                // -- ispis/info

                if (redniBroj == 0)
                {
                    MessageBox.Show("Ne postoji student koji nema odabranu stipendiju evidentiranu", "Informacija", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show($"Uspješno ste generisali {redniBroj} stipendija", "Informacija", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }

                txtInfo.Text = info;


            };
            BeginInvoke(action);



        }

        private void frmStipendijeIB180079_FormClosed(object sender, FormClosedEventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void chbAktivan_CheckedChanged(object sender, EventArgs e)
        {
            UcitajStipendijeGodine();
        }
    }
}
