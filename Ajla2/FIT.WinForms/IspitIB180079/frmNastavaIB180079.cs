using FIT.Data;
using FIT.Data.IspitIB180079;
using FIT.Infrastructure;
using FIT.WinForms.Helpers;
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
            dgvNastava.AutoGenerateColumns = false;

            UcitajProstoriju();
            cbPredmet.DataSource = db.Predmeti.ToList();

            cbDan.SelectedIndex = 0;
            cbVrijeme.SelectedIndex = 0;
            UcitajNastave();

        }

        private void UcitajNastave()
        {
            nastave = db.NastavaIB180079
                .Include(x => x.Prostorija)
                .Include(x => x.Predmet)
                .Where(x => x.ProstorijaId == odabranaProstorija.Id).ToList();

            if (nastave != null)
            {

                dgvNastava.DataSource = null;
                dgvNastava.DataSource = nastave;
            }


        }

        private void UcitajProstoriju()
        {
            lblProstorija.Text = $"{odabranaProstorija.Naziv} - {odabranaProstorija.Oznaka}";
        }

        private void button1_Click(object sender, EventArgs e)
        {

            var predmet = cbPredmet.SelectedItem as PredmetiIB180079;
            var dan = cbDan.SelectedItem.ToString();
            var vrijeme = cbVrijeme.SelectedItem.ToString();


            if (nastave.Exists(x => x.ProstorijaId == odabranaProstorija.Id && x.Dan == dan && x.Vrijeme == vrijeme))
            {
                MessageBox.Show("Termin je vec zakazan");
            }
            else
            {
                var novaNastava = new NastavaIB180079()
                {
                    ProstorijaId = odabranaProstorija.Id,
                    PredmetId = predmet.Id,
                    Dan = dan,
                    Vrijeme = vrijeme,
                    Oznaka = $"{predmet} :: {dan} :: {vrijeme}"


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
