using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FIT.Data;
using FIT.Data.IspitIB230030;
using FIT.Infrastructure;
using FIT.WinForms.Helpers;

namespace FIT.WinForms.ispitIB230030
{
    public partial class frmGradoviIB230030 : Form
    {
        private DrzaveIB230030 odabranaDrzava;
        DLWMSDbContext db = new DLWMSDbContext();
        List<GradoviIB230030> gradovi;

        public frmGradoviIB230030(DrzaveIB230030 odabranaDrzava)
        {
            InitializeComponent();
            this.odabranaDrzava = odabranaDrzava;
        }

        private void frmGradoviIB230030_Load(object sender, EventArgs e)
        {
            dgvGradovi.AutoGenerateColumns = false;
            ucitajInfo();
            ucitajGradovi();
        }

        private void ucitajGradovi()
        {
            gradovi = db.GradoviIB230030.Where(x => x.DrzavaID == odabranaDrzava.Id).ToList();
            if (gradovi != null)
            {
                dgvGradovi.DataSource = null;
                dgvGradovi.DataSource = gradovi;
            }
        }

        private void ucitajInfo()
        {
            pbZastava.Image = odabranaDrzava.Zastava.ToImage();
            lblNazivDrzave.Text = odabranaDrzava.Naziv;
        }

        private void dgvGradovi_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var odarbraniGrad = gradovi[e.RowIndex];
            if (e.ColumnIndex == 2)
            {
                odarbraniGrad.Status = odarbraniGrad.Status ? false : true;

                db.GradoviIB230030.Update(odarbraniGrad);
                db.SaveChanges();

                ucitajGradovi();
            }
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            if (Validacija())
            {
                var naziv = txtNaziv.Text;

                if (gradovi.Exists(x => x.Naziv.ToLower() == naziv.ToLower()))
                {
                    MessageBox.Show($"Grad {naziv} vec postoji u drzavi {odabranaDrzava.Naziv}", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    var noviGrad = new GradoviIB230030()
                    {
                        Naziv = naziv,
                        Status = true,
                        DrzavaID = odabranaDrzava.Id,
                    };
                    db.GradoviIB230030.Add(noviGrad);
                    db.SaveChanges();

                    txtNaziv.Clear();
                }
                ucitajGradovi();
            }
        }

        private bool Validacija()
        {
            return Validator.ProvjeriUnos(txtNaziv, err, Kljucevi.ReqiredValue);
        }

        private void frmGradoviIB230030_FormClosed(object sender, FormClosedEventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private async void btnGenerisi_Click(object sender, EventArgs e)
        {
            if (ValidirajMultiThreading())
            {

                await Task.Run(() => generisiGradove());

                //Thread t1 = new Thread(() => generisiGradove());
                //t1.Start();

            }
        }

        private void generisiGradove()
        {
            var broj = int.Parse(txtBroj.Text);
            
            var status = chbStatus.Checked;
            var info = "";

            for (int i = 1; i <= broj; i++)
            {
                Thread.Sleep(300);
                
                var noviGrad = new GradoviIB230030()
                {
                    Naziv= $"Grad {i}.",
                    Status=status,
                    DrzavaID=odabranaDrzava.Id
                };

                db.GradoviIB230030.Add(noviGrad);
                db.SaveChanges();

                info += $"{DateTime.Now.ToString("dd.MM HH:mm:ss")} -> dodat grad " +
                    $"{noviGrad.Naziv} za drzavu {odabranaDrzava}{Environment.NewLine}";
            }

            Action action = () =>
            {
                MessageBox.Show($"dodali ste {broj} grada u {odabranaDrzava.Naziv}",
                    "info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ucitajGradovi();
                txtInfo.Text = info;
            };
            BeginInvoke(action);
        }

        private bool ValidirajMultiThreading()
        {
            return Validator.ProvjeriUnos(txtBroj, err, Kljucevi.ReqiredValue);
        }
    }
}
