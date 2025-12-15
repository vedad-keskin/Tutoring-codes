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
        DLWMSContext db = new DLWMSContext();
        private Student? odabraniStudent;

        public frmRazmjeneIB180079(Student? odabraniStudent)
        {
            InitializeComponent();
            this.odabraniStudent = odabraniStudent;
        }

        private void frmRazmjeneIB180079_Load(object sender, EventArgs e)
        {
            dgvRazmjene.AutoGenerateColumns = false;

            cbDrzava.DataSource = db.Drzave.ToList();

            Text = $"Razmjene studenta: {odabraniStudent}";

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
                var ects =  int.Parse(txtECTS.Text);

                var datumPocetak = dtpDatumPocetak.Value;
                var datumKraj = dtpDatumKraj.Value;

                var okoncana = datumKraj > DateTime.Now ? false : true;

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

        private bool ValidirajUnos()
        {

            return Helpers.Validator.ProvjeriUnos(cbUniverzitet, err, Kljucevi.RequiredField) && Helpers.Validator.ProvjeriUnos(txtECTS, err, Kljucevi.RequiredField);


        }
    }
}
