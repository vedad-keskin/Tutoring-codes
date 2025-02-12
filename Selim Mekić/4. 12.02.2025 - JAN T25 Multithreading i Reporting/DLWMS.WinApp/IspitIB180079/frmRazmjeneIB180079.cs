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
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DLWMS.WinApp.IspitIB180079
{
    public partial class frmRazmjeneIB180079 : Form
    {
        private Student odabraniStudent;
        DLWMSContext db = new DLWMSContext();
        List<RazmjeneIB180079> razmjene;

        public frmRazmjeneIB180079(Student odabraniStudent)
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

            this.Text = $"Razmjene studenta {odabraniStudent.StudentInfo}";

        }

        private void dgvRazmjene_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var odabranaRazmjena = razmjene[e.RowIndex];

            if (e.ColumnIndex == 5)
            {

                if (MessageBox.Show($"Da li ste sigurni da želite obrisati podatke o razmjeni {odabraniStudent.StudentInfo} na {odabranaRazmjena.Univerzitet}", "Upit", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
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
            if (Validiraj())
            {

                var univerzitet = cbUniverzitet.SelectedItem as UniverzitetiIB180079;



                //var ects = int.Parse(txtECTS.Text);
                var ects = int.TryParse(txtECTS.Text, out var result) ? result : 1;


                var datumPocetak = dtpPocetak.Value;
                var datumKraj = dtpKraj.Value;

                var okoncana = datumKraj > DateTime.Now ? false : true;


                if (datumKraj < datumPocetak)
                {
                    MessageBox.Show($"Datum kraja mora biti veći od datum početka", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (razmjene.Exists(x =>
                (datumPocetak >= x.DatumPocetak && datumPocetak <= x.DatumKraj)
                ||
                (datumKraj >= x.DatumPocetak && datumKraj <= x.DatumKraj)
                ||
                (datumPocetak <= x.DatumPocetak && datumKraj >= x.DatumKraj)
                ))
                {
                    MessageBox.Show($"Postoji konfikt u datumu", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {

                    var novaRazmjena = new RazmjeneIB180079()
                    {
                        StudentId = odabraniStudent.Id,
                        UniverzitetId = univerzitet.Id,
                        DatumPocetak = datumPocetak,
                        DatumKraj = datumKraj,
                        ECTS = ects,
                        Okoncana = okoncana
                    };

                    db.RazmjeneIB180079.Add(novaRazmjena);
                    db.SaveChanges();

                    UcitajRazmjene();

                }



            }
        }

        private bool Validiraj()
        {
            return Validator.ProvjeriUnos(txtECTS, err, Kljucevi.RequiredField)
                &&
                Validator.ProvjeriUnos(cbUniverzitet, err, Kljucevi.RequiredField);
        }

        private void btnGenerisi_Click(object sender, EventArgs e)
        {

            if (ValidirajMultithreading())
            {
                var odabraniUniverzitet = cbUniverzitetMultithreading.SelectedItem as UniverzitetiIB180079;

                Thread thread = new Thread(() => GenerisiRazmjene(odabraniUniverzitet));

                thread.Start();

            }

        }

        private void GenerisiRazmjene(UniverzitetiIB180079? odabraniUniverzitet)
        {

            var broj = int.TryParse(txtBroj.Text, out var result1) ? result1 : 1;

            var ects = int.TryParse(txtECTSMultithreading.Text, out var result2) ? result2 : 1;

            var info = "";

            var datumPocetak = new DateTime(2025, 1, 1, 12, 0, 0);



            for (int i = 0; i < broj; i++)
            {

                Thread.Sleep(300);

                var datumKraj = datumPocetak.AddDays(ects + (i + 1));

                var okoncana = datumKraj > DateTime.Now ? false : true;


                var novaRazmjena = new RazmjeneIB180079()
                {
                    StudentId = odabraniStudent.Id,
                    UniverzitetId = odabraniUniverzitet.Id,
                    DatumKraj = datumKraj,
                    DatumPocetak = datumPocetak,
                    Okoncana = okoncana,
                    ECTS = ects

                };

                info += $"{i + 1}. razmjena za {odabraniStudent.StudentInfo}  na {odabraniUniverzitet.Naziv} ({novaRazmjena.DatumPocetak.ToString("dd.MM.yyyy")} - {novaRazmjena.DatumKraj.ToString("dd.MM.yyyy")}){Environment.NewLine}";

                db.RazmjeneIB180079.Add(novaRazmjena);
                db.SaveChanges();


            }

            Action action = () =>
            {
                UcitajRazmjene();
                MessageBox.Show($"Uspješno je generisano {broj} razmjena", "Informacija", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtInfo.Text = info;

            };
            BeginInvoke(action);


        }

        private bool ValidirajMultithreading()
        {
            return Validator.ProvjeriUnos(txtECTSMultithreading, err, Kljucevi.RequiredField)
                &&
                Validator.ProvjeriUnos(txtBroj, err, Kljucevi.RequiredField);
        }

        private void btnPotvrda_Click(object sender, EventArgs e)
        {

            var frmIzvjestaj = new frmIzvjestaji(odabraniStudent);

            frmIzvjestaj.ShowDialog();


        }
    }
}
