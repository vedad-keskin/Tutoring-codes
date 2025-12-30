using DLWMS.Data;
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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DLWMS.WinApp.IspitIB180079
{
    public partial class frmRazmjeneIB180079 : Form
    {
        DLWMSContext db = new DLWMSContext();
        private Student? odabraniStudent;
        List<RazmjeneIB180079> razmjene;

        public frmRazmjeneIB180079(Student? odabraniStudent)
        {
            InitializeComponent();
            this.odabraniStudent = odabraniStudent;
        }

        private void frmRazmjeneIB180079_Load(object sender, EventArgs e)
        {
            dgvRazmjene.AutoGenerateColumns = false;

            cbDrzava.DataSource = db.Drzave.ToList();

            cbUniverzitetMultithreading.DataSource = db.UniverzitetiIB180079.ToList();

            cbUniverzitetMultithreading.DisplayMember = "Naziv";


            Text = $"Razmjene studenta: {odabraniStudent}";

            UcitajRazmjene();

        }

        private void UcitajRazmjene()
        {

            razmjene = db.RazmjeneIB180079
                .Include(x => x.Univerzitet.Drzava)
                .Where(x => x.StudentId == odabraniStudent.Id)
                .ToList();

            if (razmjene != null)
            {

                dgvRazmjene.DataSource = null;
                dgvRazmjene.DataSource = razmjene;

            }

        }

        private void dgvRazmjene_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 5)
            {

                var odabranaRazmjena = dgvRazmjene.SelectedRows[0].DataBoundItem as RazmjeneIB180079;

                if (MessageBox.Show($"Da li ste sigurni da želite obrisati podatke o razmjeni {odabraniStudent} na {odabranaRazmjena.Univerzitet}", "Upit", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {

                    db.RazmjeneIB180079.Remove(odabranaRazmjena);
                    db.SaveChanges();

                    UcitajRazmjene();


                }


            }
        }

        private void cbDrzava_SelectedIndexChanged(object sender, EventArgs e)
        {

            var odabranaDrzava = cbDrzava.SelectedItem as Drzava;

            cbUniverzitet.DataSource = db.UniverzitetiIB180079
                .Where(x => x.DrzavaId == odabranaDrzava.Id)
                .ToList();

            cbUniverzitet.DisplayMember = "Naziv";

        }

        private void btnSacuvaj_Click(object sender, EventArgs e)
        {

            if (ValidirajUnos())
            {

                var odabraniUniverzitet = cbUniverzitet.SelectedItem as UniverzitetiIB180079;


                // STRING --> INT
                var ects = int.Parse(txtECTS.Text);

                var datumPocetak = dtpDatumPocetak.Value;
                var datumKraj = dtpDatumKraj.Value;

                var okoncana = datumKraj > DateTime.Now ? false : true;

                if (datumPocetak > datumKraj)
                {

                    MessageBox.Show("Datum početka ne smije biti veći od datuma kraja", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
                else if (razmjene.Exists
                (x => (datumPocetak >= x.DatumPocetak && datumPocetak <= x.DatumKraj)
                ||
                (datumKraj >= x.DatumPocetak && datumKraj <= x.DatumKraj)
                ||
                (datumPocetak <= x.DatumPocetak && datumKraj >= x.DatumKraj)
                ))
                {

                    MessageBox.Show("Postoji konflikt u odnosu na ostale razmjene", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
                else
                {

                    var novaRazmjena = new RazmjeneIB180079()
                    {
                        StudentId = odabraniStudent.Id,
                        UniverzitetId = odabraniUniverzitet.Id,
                        DatumPocetak = datumPocetak,
                        DatumKraj = datumKraj,
                        ECTS = ects,
                        Okoncana = okoncana,
                    };

                    db.RazmjeneIB180079.Add(novaRazmjena);
                    db.SaveChanges();

                    UcitajRazmjene();
                }


            }



        }

        private bool ValidirajUnos()
        {

            return Helpers.Validator.ProvjeriUnos(cbUniverzitet, err, Kljucevi.RequiredField) && Helpers.Validator.ProvjeriUnos(txtECTS, err, Kljucevi.RequiredField);


        }
        private bool ValidirajUnosMultithreadinga()
        {
            return Helpers.Validator.ProvjeriUnos(cbUniverzitetMultithreading, err, Kljucevi.RequiredField) && Helpers.Validator.ProvjeriUnos(txtECTSMultithreading, err, Kljucevi.RequiredField) &&
                Helpers.Validator.ProvjeriUnos(txtBroj, err, Kljucevi.RequiredField);
        }

        private async void btnGenerisi_Click(object sender, EventArgs e)
        {

            // 1. dio
            // -- async i await
            // -- validacije
            // -- ako postoji neki combo box, mora se pohraniti ovdje

            if (ValidirajUnosMultithreadinga())
            {

                var univerzitet = cbUniverzitetMultithreading.SelectedItem as UniverzitetiIB180079;

                await Task.Run(() => GenrisiRazmjene(univerzitet));

            }
        }


        private void GenrisiRazmjene(UniverzitetiIB180079? univerzitet)
        {
            // 2. dio
            // -- kalkulacije
            // -- sleep
            // -- pohrane

            var ects = int.Parse(txtECTSMultithreading.Text); // 10

            var broj = int.Parse(txtBroj.Text);


            var datumPocetak = new DateTime(2025, 1, 1, 12, 0, 0); // 1.1.2025

            var info = "";

            // datumKraj = datumPocetak + ects + redni broj razmj.

            // 1.1 + 10 + 1 ---> datumKraj = 12.1
            // 1.1 + 10 + 2 ---> datumKraj = 13.1
            // 1.1 + 10 + 3 ---> datumKraj = 14.1

            for (int i = 1; i < broj + 1; i++)
            {

                Thread.Sleep(300);

                var datumKraj = datumPocetak.AddDays(ects + i); // datumP + ects + redni

                var okoncana = datumKraj > DateTime.Now ? false : true;

                var novaRazmjena = new RazmjeneIB180079()
                {
                    StudentId = odabraniStudent.Id,
                    UniverzitetId = univerzitet.Id,
                    DatumPocetak = datumPocetak,
                    DatumKraj = datumKraj,
                    ECTS = ects,
                    Okoncana = okoncana,
                };

                info += $"{i}. razmjena za {odabraniStudent} na {univerzitet.Naziv} ({datumPocetak.ToString("dd.MM.yyyy")} - {datumKraj.ToString("dd.MM.yyyy")}){Environment.NewLine}";

                db.RazmjeneIB180079.Add(novaRazmjena);
                db.SaveChanges();


            }


            Action action = () =>
            {
                // 3. dio
                // -- ispisi
                // -- mbox
                // -- ucitavanja

                MessageBox.Show($"Uspješno je generisano {broj} razmjena", "Informacija", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtInfo.Text = info;

                UcitajRazmjene();

            };
            BeginInvoke(action);




        }

        private void btnPotvrda_Click(object sender, EventArgs e)
        {

            var frmIzvjestaj = new frmIzvjestaji(odabraniStudent);


            frmIzvjestaj.ShowDialog();

        }
    }
}
