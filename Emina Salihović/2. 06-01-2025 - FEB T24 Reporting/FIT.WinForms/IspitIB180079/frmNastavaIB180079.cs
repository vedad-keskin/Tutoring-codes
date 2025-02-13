using FIT.Data.IspitIB180079;
using FIT.Infrastructure;
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

namespace FIT.WinForms.IspitIB180079
{
    public partial class frmNastavaIB180079 : Form
    {
        private ProstorijeIB180079 odabranaProstorija;
        DLWMSDbContext db = new DLWMSDbContext();
        List<NastavaIB180079> nastave;

        public frmNastavaIB180079(ProstorijeIB180079 odabranaProstorija)
        {
            InitializeComponent();
            this.odabranaProstorija = odabranaProstorija;
        }

        private void frmNastavaIB180079_Load(object sender, EventArgs e)
        {
            dgvNastave.AutoGenerateColumns = false;
            lblNazivProstorije.Text = $"{odabranaProstorija.Naziv} - {odabranaProstorija.Oznaka}";

            // COMBO BOX

            // IZ BAZE 

            cbPredmet.DataSource = db.Predmeti.ToList();

            // RUCNO UNESEMO PODATKE

            cbDan.SelectedIndex = 0;
            cbVrijeme.SelectedIndex = 0;


            UcitajNastave();
        }

        private void UcitajNastave()
        {

            // Id ProstorijaId NastavaId Vrijeme Dan Oznaka
            // -> Naziv Id Semestar

            nastave = db.NastavaIB180079
                .Include(x => x.Predmet)
                .Include(x => x.Prostorija)
                .Where(x => x.ProstorijaId == odabranaProstorija.Id)
                .ToList();


            if (nastave != null)
            {
                dgvNastave.DataSource = null;
                dgvNastave.DataSource = nastave;
            }
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {

            // CB IZ BAZE

            // OBJECT -> PREDMET

            var predmet = cbPredmet.SelectedItem as PredmetiIB180079;

            // RUCNI CB 

            var dan = cbDan.SelectedItem.ToString(); // "Ponedeljak"

            var vrijeme = cbVrijeme.SelectedItem.ToString(); // "08 - 10"



            if (nastave.Exists(x=> x.Vrijeme == vrijeme && x.Dan == dan)  )
            {
                MessageBox.Show("Nastava već postoji u tom terminu","Upozorenje",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
            }
            else
            {

                var novaNastava = new NastavaIB180079()
                {
                    // Predmet = predmet, AKO KLASU POSALJEMO BAZA PUCA

                    Dan = dan,
                    Vrijeme = vrijeme,
                    PredmetId = predmet.Id,
                    ProstorijaId = odabranaProstorija.Id,
                    Oznaka = $"{predmet.Naziv} :: {dan} :: {vrijeme}"

                };

                db.NastavaIB180079.Add(novaNastava);
                db.SaveChanges();
            }



            UcitajNastave();


        }

        private void frmNastavaIB180079_FormClosed(object sender, FormClosedEventArgs e)
        {

            DialogResult = DialogResult.OK;
        }
    }
}
