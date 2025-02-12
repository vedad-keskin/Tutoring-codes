using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FIT.Data.ispitIB230030;
using FIT.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace FIT.WinForms.ispitIB230030
{
    public partial class frmNastavaIB230030 : Form
    {
        private ProstorijeIB230030 odabranaProstorija;
        DLWMSDbContext db = new DLWMSDbContext();
        List<NastavaIB230030> nastava;

        public frmNastavaIB230030(ProstorijeIB230030 odabranaProstorija)
        {
            InitializeComponent();
            this.odabranaProstorija = odabranaProstorija;
        }

        private void frmNastavaIB230030_Load(object sender, EventArgs e)
        {
            dgvNastava.AutoGenerateColumns = false;
            lblProstorija.Text = $"{odabranaProstorija.Naziv} - {odabranaProstorija.Oznaka}";
            ucitajNastavu();
            ucitajComboBox();
        }

        private void ucitajComboBox()
        {
            cbPredmet.DataSource = db.Predmeti.ToList();
            cbDan.SelectedIndex = 0;
            cbVrijeme.SelectedIndex = 0;
        }

        private void ucitajNastavu()
        {
            nastava = db.NastavaIB230030.Include(x=>x.Predmet) .Where(x => x.ProstorijaID == odabranaProstorija.Id).ToList();
            if (nastava != null)
            {
                dgvNastava.DataSource = null;
                dgvNastava.DataSource = nastava;
            }
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            var predmet = cbPredmet.SelectedItem as PredmetiIB230030;
            var dan = cbDan.SelectedItem.ToString();
            var vrijeme = cbVrijeme.SelectedItem.ToString();

            if(nastava.Exists(x=> x.Dan==dan && x.Vrijeme == vrijeme))
            {
                MessageBox.Show("Već postoji nastava u toj prostoriji ", "warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                var novaNastava = new NastavaIB230030()
                {
                    Dan = dan,
                    Vrijeme = vrijeme,
                    PredmetID = predmet.Id,
                    ProstorijaID = odabranaProstorija.Id,
                    Oznaka = $"{predmet} :: {dan} :: {vrijeme}"
                };

                db.NastavaIB230030.Add(novaNastava);
                db.SaveChanges();
            }

            ucitajNastavu();
        }

        private void frmNastavaIB230030_FormClosed(object sender, FormClosedEventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}
