using FIT.Data.IspitIB210166;
using FIT.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FIT.WinForms.IspitIB210166
{
    public partial class frmNastavaIB180079 : Form
    {
        private ProstorijeIB210166 odabranaProstorija;
        DLWMSDbContext db = new DLWMSDbContext();
        List<NastavaIB210166> nastave;

        public frmNastavaIB180079(ProstorijeIB210166 odabranaProstorija)
        {
            InitializeComponent();
            this.odabranaProstorija = odabranaProstorija;
        }

        private void frmNastavaIB180079_Load(object sender, EventArgs e)
        {
            dgvNastave.AutoGenerateColumns = false;
            lblNazivProstorije.Text = $"{odabranaProstorija.Naziv} - {odabranaProstorija.Oznaka}";

            cbPredmet.DataSource = db.Predmeti.ToList();


            cbDan.SelectedIndex = 0;
            cbVrijeme.SelectedIndex = 0;

            UcitajNastave();

        }

        private void UcitajNastave()
        {
            nastave = db.NastavaIB210166
                .Where(x => x.ProstorijeId == odabranaProstorija.Id)
                .ToList();

            if (nastave != null)
            {

                dgvNastave.DataSource = null;
                dgvNastave.DataSource = nastave;
            }
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {

            var predmet = cbPredmet.SelectedItem as PredmetiIB210166;
            var dan = cbDan.SelectedItem.ToString(); // "Ponedeljak"
            var vrijeme = cbVrijeme.SelectedItem.ToString(); // "08 - 10


            if (nastave.Exists(x=> x.Dan == dan && x.Vrijeme == vrijeme ))
            {
                MessageBox.Show("Nastava već postoji na tom terminu","Upozorenje",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
            else
            {
                var novaNastava = new NastavaIB210166()
                {
                    // Predmet, Id, Prostorija ne mogu ici na bazu

                    Dan = dan,
                    Vrijeme = vrijeme,
                    PredmetId = predmet.Id,
                    ProstorijeId = odabranaProstorija.Id,
                    Oznaka = $"{predmet.Naziv} :: {dan} :: {vrijeme}"


                };

                db.NastavaIB210166.Add(novaNastava);
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
