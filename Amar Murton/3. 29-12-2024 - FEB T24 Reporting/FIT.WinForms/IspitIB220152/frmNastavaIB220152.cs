using FIT.Data;
using FIT.Data.IspitIB220152;
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

namespace FIT.WinForms.IspitIB220152
{
    public partial class frmNastavaIB220152 : Form
    {
        DLWMSDbContext db = new DLWMSDbContext();
        private ProstorijeIB220152 odabranaProstorija;
        List<NastavaIB220152> nastave;

        public frmNastavaIB220152(ProstorijeIB220152 odabranaProstorija)
        {
            InitializeComponent();
            this.odabranaProstorija = odabranaProstorija;
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            if (Validiraj())
            {

                var predmet = cbPredmet.SelectedItem as PredmetiIB220152;

                var dan = cbDan.SelectedItem.ToString(); // "Pondeljak"

                var vrijeme = cbVrijeme.SelectedItem.ToString(); // "08 - 10


                if (nastave.Exists(x => x.Dan == dan && x.Vrijeme == vrijeme))
                {
                    MessageBox.Show("Nastava već postoji u tom terminu", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    var novaNastava = new NastavaIB220152()
                    {
                        Dan = dan,
                        Vrijeme = vrijeme,
                        ProstorijeId = odabranaProstorija.Id,
                        PredmetId = predmet.Id,
                        Oznaka = $"{predmet.Naziv} :: {dan} :: {vrijeme}"


                    };

                    db.NastavaIB220152.Add(novaNastava);
                    db.SaveChanges();

                }



                UcitajNastave();


            }
        }

        private void UcitajPredmete()
        {

            cbPredmet.DataSource = db.Predmeti.ToList();

        }

        private bool Validiraj()
        {
            return Helpers.Validator.ProvjeriUnos(cbDan, err, Kljucevi.ReqiredValue)
                && Helpers.Validator.ProvjeriUnos(cbVrijeme, err, Kljucevi.ReqiredValue);
        }

        private void frmNastavaIB220152_Load(object sender, EventArgs e)
        {
            dgvNastava.AutoGenerateColumns = false;
            lblNazivProstorije.Text = $"{odabranaProstorija.Naziv} - {odabranaProstorija.Oznaka}";

            cbDan.SelectedIndex = 0;
            cbVrijeme.SelectedIndex = 0;

            UcitajPredmete();
            UcitajNastave();
        }

        private void UcitajNastave()
        {
            nastave = db.NastavaIB220152
                .Where(x => x.ProstorijeId == odabranaProstorija.Id)
                .ToList();

            if (nastave != null)
            {
                dgvNastava.DataSource = null;
                dgvNastava.DataSource = nastave;
            }

        }

        private void frmNastavaIB220152_FormClosed(object sender, FormClosedEventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}
