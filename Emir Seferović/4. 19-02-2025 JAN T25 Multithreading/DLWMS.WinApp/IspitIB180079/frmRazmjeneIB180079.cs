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

            this.Text = $"Razmjene studenta: {odabraniStudent.StudentInfo}";

            UcitajRazmjene();

            cbDrzava.DataSource = db.Drzave.ToList();

            // za Multithreading

            cbUniverzitetM.DataSource = db.UniverzitetiIB180079.ToList();

            cbUniverzitetM.DisplayMember = "Naziv";

            // suma ECTS 

            //var sumaECTS = razmjene.Sum(x => x.ECTS);


        }

        private void UcitajRazmjene()
        {
            razmjene = db.RazmjeneIB180079
                .Include(x => x.Univerzitet.Drzava)
                .Include(x => x.Student)
                .Where(x => x.StudentId == odabraniStudent.Id)
                .ToList();

            if (razmjene != null)
            {
                dgvRazmjene.DataSource = null;
                dgvRazmjene.DataSource = razmjene;
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

                var odabraniUniverzitet = cbUniverzitet.SelectedItem as UniverzitetiIB180079;

                var ects = int.Parse(txtECTS.Text);

                var datumPocetak = dtpDatumPocetak.Value;
                var datumKraj = dtpDatumKraj.Value;

                //var okoncana = true;
                var okoncana = datumKraj > DateTime.Now ? false : true;


                if (datumPocetak > datumKraj)
                {
                    MessageBox.Show($"Datum početka mora biti manji od datuma kraja", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (razmjene.Exists(x =>
                (datumPocetak >= x.DatumPocetak && datumPocetak <= x.DatumKraj)
                ||
                (datumKraj >= x.DatumPocetak && datumKraj <= x.DatumKraj)
                ||
                (datumPocetak <= x.DatumPocetak && datumKraj >= x.DatumKraj)
                ))
                {
                    MessageBox.Show($"Postoji konfikt u datumima razmjena", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {

                    var novaRazmjena = new RazmjeneIB180079()
                    {
                        StudentId = odabraniStudent.Id,
                        UniverzitetId = odabraniUniverzitet.Id,
                        ECTS = ects,
                        DatumPocetak = datumPocetak,
                        DatumKraj = datumKraj,
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

        private void btnGenerisi_Click(object sender, EventArgs e)
        {

            if (ValidirajM())
            {
                var odabraniUniverzitet = cbUniverzitetM.SelectedItem as UniverzitetiIB180079;

                Thread thread = new Thread(() => GenerisiRazjene(odabraniUniverzitet));
                thread.Start();

            }

        }

        private void GenerisiRazjene(UniverzitetiIB180079? odabraniUniverzitet)
        {

            var broj = int.Parse(txtBroj.Text);

            var ects = int.Parse(txtECTSM.Text);

            //var datumPocetak = DateTime.Now;
            //var datumPocetak = new DateTime(2025, 1, 1, 12, 0, 0);
            var datumPocetak = new DateTime(2025, 1, 1);

            //var datumKraj = DateTime.Now;

            //var okoncana = true;

            var info = "";


            for (int i = 0; i < broj; i++)
            {
                Thread.Sleep(300);

                var datumKraj = datumPocetak.AddDays(ects + (i + 1));

                var okoncana = datumKraj > DateTime.Now ? false : true;

                var novaRazmjena = new RazmjeneIB180079()
                {

                    StudentId = odabraniStudent.Id,
                    UniverzitetId = odabraniUniverzitet.Id,
                    ECTS = ects,
                    DatumPocetak = datumPocetak,
                    DatumKraj = datumKraj,  
                    Okoncana = okoncana

                };

                info += $"{i+1}. razmjena {odabraniStudent.StudentInfo} na {odabraniUniverzitet.Naziv} ({datumPocetak.ToString("dd.MM.yyyy")} - {datumKraj.ToString("dd.MM.yyyy")}){Environment.NewLine}";

                db.RazmjeneIB180079.Add(novaRazmjena);
                db.SaveChanges();
                

            }




            Action action = () =>
            {

                UcitajRazmjene();
                MessageBox.Show($"Uspješno ste generisali {broj} razmjena", "Informacija", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtInfo.Text = info;

            };
            BeginInvoke(action);



        }

        private bool ValidirajM()
        {
            return Validator.ProvjeriUnos(txtBroj, err, Kljucevi.RequiredField)
                &&
                Validator.ProvjeriUnos(txtECTSM, err, Kljucevi.RequiredField);
        }
    }
}
