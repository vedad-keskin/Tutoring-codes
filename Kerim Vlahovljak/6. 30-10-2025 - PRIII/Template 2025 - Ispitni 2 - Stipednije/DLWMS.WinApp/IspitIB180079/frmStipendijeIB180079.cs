using DLWMS.Data.IspitIB180079;
using DLWMS.Infrastructure;
using DLWMS.WinApp.Helpers;
using DLWMS.WinApp.Izvjestaji;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Formats.Asn1;
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

            UcitajComobox();

            UcitajStipendijeGodine();

        }

        private void UcitajComobox()
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

        private void dgvStipendijeGodine_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            var odabranaStipendijaGodina = dgvStipendijeGodine.SelectedRows[0].DataBoundItem as StipendijeGodineIB180079;


            //if(odabranaStipendijaGodina.Aktivna)
            //{
            //    odabranaStipendijaGodina.Aktivna = false;
            //}
            //else
            //{
            //    odabranaStipendijaGodina.Aktivna = true;
            //}

            //odabranaStipendijaGodina.Aktivna = odabranaStipendijaGodina.Aktivna ? false : true;


            odabranaStipendijaGodina.Aktivna = !odabranaStipendijaGodina.Aktivna;

            db.StipendijeGodineIB180079.Update(odabranaStipendijaGodina);

            db.SaveChanges();

            UcitajStipendijeGodine();

        }

        private async void btnGenerisi_Click(object sender, EventArgs e)
        {
            // 1. dio
            // -- postavljanje threada
            // -- validacija
            // -- ako imamo combobox moramo ga pohraniti u prvom dijelu

            await Task.Run(() => GenerisiStipendije());


        }

        private void GenerisiStipendije()
        {
            // 2. dio
            // -- pohrane
            // -- kalkulacije
            // -- sleep

            var stipendijaGodina = dgvStipendijeGodine.SelectedRows[0].DataBoundItem as StipendijeGodineIB180079;


            var sviStudenti = db.Studenti.ToList();

            var info = "";

            var redniBroj = 1;

            for (int i = 0; i < sviStudenti.Count(); i++)
            {

                if (!db.StudentiStipendijeIB180079.ToList().Exists(x => x.StudentId == sviStudenti[i].Id &&
                x.StipendijaGodinaId == stipendijaGodina.Id))
                {
                    Thread.Sleep(300);

                    var novaStudentStipendija = new StudentiStipendijeIB180079()
                    {
                        StudentId = sviStudenti[i].Id,
                        StipendijaGodinaId = stipendijaGodina.Id

                    };

                    db.StudentiStipendijeIB180079.Add(novaStudentStipendija);
                    db.SaveChanges();

                    info += $"{redniBroj}. {stipendijaGodina} stipendija u iznosu od {stipendijaGodina.Iznos} dodata {sviStudenti[i]}{Environment.NewLine}";

                    redniBroj++;

                }

            }




            Action action = () =>
            {

                // 3. dio
                // -- mbox
                // -- ispis
                // -- ucitavanje

                MessageBox.Show("Uspješno su generisane stipendije studentima", "Informacija", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtInfo.Text = info;

            };
            BeginInvoke(action);



        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {

            if (ValidirajUnos())
            {

                var godina = cbGodina.SelectedItem.ToString(); // "2025" "2024"

                var stipendija = cbStipendija.SelectedItem as StipendijeIB180079;


                // STRING -> INT
                var iznos = int.Parse(txtIznos.Text); // "230" -> 230


                if (db.StipendijeGodineIB180079.ToList().Exists(x => x.StipendijaId == stipendija.Id
                && x.Godina == godina))
                {
                    MessageBox.Show($"Odabrana stipendija {stipendija} već postoji na {godina}", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    var novaStipendijaGodina = new StipendijeGodineIB180079()
                    {

                        Godina = godina,
                        StipendijaId = stipendija.Id,
                        Iznos = iznos,
                        Aktivna = true

                    };

                    db.StipendijeGodineIB180079.Add(novaStipendijaGodina);
                    db.SaveChanges();

                    UcitajStipendijeGodine();

                }




            }

        }

        private bool ValidirajUnos()
        {

            return Validator.ProvjeriUnos(txtIznos, err, "Ovo polje je obavezno");

        }

        private void btnPotvrda_Click(object sender, EventArgs e)
        {

            var odabranaStipendijaGodina = dgvStipendijeGodine.SelectedRows[0].DataBoundItem as StipendijeGodineIB180079;

            var frmIzvjestaj = new frmIzvjestaji(odabranaStipendijaGodina);

            frmIzvjestaj.ShowDialog();

        }
    }
}
