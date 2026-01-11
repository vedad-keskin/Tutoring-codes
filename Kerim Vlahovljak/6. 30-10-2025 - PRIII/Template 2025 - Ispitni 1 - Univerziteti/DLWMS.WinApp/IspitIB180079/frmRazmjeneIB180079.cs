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
    public partial class frmRazmjeneIB180079 : Form
    {
        private Student? odabraniStudent;
        DLWMSContext db = new DLWMSContext();

        //public frmRazmjeneIB180079()
        //{
        //    InitializeComponent();
        //}

        public frmRazmjeneIB180079(Student? odabraniStudent)
        {
            InitializeComponent();
            this.odabraniStudent = odabraniStudent;
        }

        private void frmRazmjeneIB180079_Load(object sender, EventArgs e)
        {
            dgvRazmjene.AutoGenerateColumns = false;

            Text = $"Razmjene studenta: {odabraniStudent}";

            cbDrzava.DataSource = db.Drzave.ToList();

            cbUniverzitetMT.DataSource = db.UniverzitetiIB180079.ToList();

            UcitajRazmjene();

        }

        private void UcitajRazmjene()
        {

            var razmjene = db.RazmjeneIB180079
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

                if (MessageBox.Show($"Da li ste sigurni da želite obrisati podatke o razmjeni {odabraniStudent} na {odabranaRazmjena.UniverzitetInfo}", "Upit", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
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

        }

        private void btnSacuvaj_Click(object sender, EventArgs e)
        {

            if (ValidirajUnos())
            {

                var odabraniUniverzitet = cbUniverzitet.SelectedItem as UniverzitetiIB180079;

                // STRING -> INT 
                var ects = int.Parse(txtECTS.Text);

                var datumPocetak = dtpDatumPocetak.Value;

                var datumKraj = dtpDatumKraj.Value;

                var okoncano = datumKraj > DateTime.Now ? false : true;


                if (datumKraj < datumPocetak)
                {
                    MessageBox.Show("Datum početka ne može biti veći od datuma kraja", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (db.RazmjeneIB180079
                .Where(x => x.StudentId == odabraniStudent.Id)
                .ToList().Exists(x =>
                    (datumKraj >= x.DatumPocetak && datumKraj <= x.DatumKraj) ||
                    (datumPocetak >= x.DatumPocetak && datumPocetak <= x.DatumKraj) ||
                    (datumPocetak <= x.DatumPocetak && datumKraj >= x.DatumKraj)
                    ))
                {

                    MessageBox.Show("Datum je u konfliktu", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);

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
                        Okoncana = okoncano
                    };

                    db.RazmjeneIB180079.Add(novaRazmjena);
                    db.SaveChanges();

                    UcitajRazmjene();


                }





            }

        }

        private bool ValidirajUnos()
        {

            return Validator.ProvjeriUnos(txtECTS, err, Kljucevi.RequiredField) &&
                Validator.ProvjeriUnos(cbUniverzitet, err, Kljucevi.RequiredField);

        }

        private async void btnGenerisi_Click(object sender, EventArgs e)
        {
            // 1. dio
            // -- validacije
            // -- postavljanje threada -> Task await i async
            // -- ako postoji combo box, taj combobox se mora pohraniti ranije

            if (ValidirajUnosMT())
            {

                var odabraniUniverzitet = cbUniverzitetMT.SelectedItem as UniverzitetiIB180079;

                await Task.Run(() => GenerisiRazmjene(odabraniUniverzitet));

            }


        }

        private void GenerisiRazmjene(UniverzitetiIB180079 odabraniUniverzitet)
        {
            // 2. dio
            // -- pohrane
            // -- kalkulacije
            // -- sleep

            var broj = int.Parse(txtBroj.Text);


            var datumPocetak = new DateTime(2025 , 1 , 1, 12, 0 , 0); // 1.1.2025

            var ects = int.Parse(txtECTSMT.Text); // 30

            var info = "";

            for (int i = 0; i < broj; i++) // 0 1 2 3 4 --> 1 2 3 4 .. 
            {

                var datumKraj = datumPocetak.AddDays(ects + (i + 1)); // 1.1.2025 + 30 + 1 -> 31.1.2025

                var okoncano = datumKraj > DateTime.Now ? false : true;

                var novaRazmjena = new RazmjeneIB180079()
                {
                    StudentId = odabraniStudent.Id,
                    UniverzitetId = odabraniUniverzitet.Id,
                    DatumPocetak = datumPocetak,
                    DatumKraj = datumKraj,
                    ECTS = ects,
                    Okoncana = okoncano,
                };

                info += $"{i + 1}. razmjena za {odabraniStudent} na {odabraniUniverzitet} ({datumPocetak.ToString("dd.MM.yyyy")} - {datumKraj.ToString("dd.MM.yyyy")}){Environment.NewLine}";

                db.RazmjeneIB180079.Add(novaRazmjena);
                db.SaveChanges();

                Thread.Sleep(300);

            }


            Action action = () =>
            {

                // 3. dio
                // -- ucitavanje
                // -- mbox
                // -- ispis

                MessageBox.Show($"Uspješno je generisano {broj} razmjena","Informacija",MessageBoxButtons.OK,MessageBoxIcon.Information);

                UcitajRazmjene();

                txtInfo.Text = info;    



            };
            BeginInvoke(action);



        }

        private bool ValidirajUnosMT()
        {
            return Validator.ProvjeriUnos(txtECTSMT, err, Kljucevi.RequiredField) &&
                Validator.ProvjeriUnos(txtBroj, err, Kljucevi.RequiredField) && 
                Validator.ProvjeriUnos(cbUniverzitetMT, err, Kljucevi.RequiredField);
        }
    }
}
