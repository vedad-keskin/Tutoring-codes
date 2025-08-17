using DLWMS.Data;
using DLWMS.Data.IspitIB180079;
using DLWMS.Infrastructure;
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
    public partial class frmNastavaIB180079 : Form
    {
        private ProstorijeIB180079 odabranaProstorija;
        DLWMSContext db = new DLWMSContext();
        List<NastavaIB180079> nastave;

        //public frmNastavaIB180079()
        //{
        //    InitializeComponent();
        //}

        public frmNastavaIB180079(ProstorijeIB180079 odabranaProstorija)
        {
            InitializeComponent();
            this.odabranaProstorija = odabranaProstorija;
        }

        private void frmNastavaIB180079_Load(object sender, EventArgs e)
        {
            dgvNastave.AutoGenerateColumns = false;

            lblNazivProstorije.Text = $"{odabranaProstorija.Naziv} - {odabranaProstorija.Oznaka}";

            UcitajNastave();

            UcitajComboBox();

        }

        private void UcitajComboBox()
        {

            cbPredmet.DataSource = db.Predmeti.ToList();

            cbVrijeme.SelectedIndex = 0;

            cbDan.SelectedIndex = 0;


        }

        private void UcitajNastave()
        {

            // Id
            // ProstorijaId
            // PredmetId
            // Dan 
            // Vrijeme 
            // Oznaka 

            // Predmet -> Id Naziv Semester .. 
            // Prostorija -> Id Naziv Kapacitet .. 

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

            var dan = cbDan.SelectedItem.ToString(); // "Ponedeljak"
            var vrijeme = cbVrijeme.SelectedItem.ToString(); // "08 - 10"

            var predmet = cbPredmet.SelectedItem as Predmet; // Id Naziv Semestar .. 

            if (nastave.Exists(x => x.Dan == dan && x.Vrijeme == vrijeme ))
            {
                MessageBox.Show("Nastavu nije moguće dodati jer je u koliziji sa drugim termina","Upozorenje",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
            else
            {
                var novaNastava = new NastavaIB180079()
                {
                    Dan = dan,
                    Vrijeme = vrijeme,
                    //Predmet = predmet, // PUCA JER PREDMET NE IDE NA BAZU
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
