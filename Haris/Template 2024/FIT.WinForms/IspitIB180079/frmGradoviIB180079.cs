using FIT.Data;
using FIT.Data.IspitIB180079;
using FIT.Infrastructure;
using FIT.WinForms.Helpers;
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
    public partial class frmGradoviIB180079 : Form
    {
        private DrzaveIB180079 odabranaDrzava;
        DLWMSDbContext db = new DLWMSDbContext();
        List<GradoviIB180079> gradovi;


        public frmGradoviIB180079(DrzaveIB180079 odabranaDrzava)
        {
            InitializeComponent();
            this.odabranaDrzava = odabranaDrzava;
        }

        private void frmGradoviIB180079_Load(object sender, EventArgs e)
        {
            dgvGradovi.AutoGenerateColumns = false;

            UcitajInfo();
            UcitajGradove();

        }

        private void UcitajGradove()
        {
            gradovi = db.GradoviIB180079
                .Where(x => x.DrzavaId == odabranaDrzava.Id)
                .ToList();

            if (gradovi != null)
            {


                dgvGradovi.DataSource = null;
                dgvGradovi.DataSource = gradovi;
            }
        }

        private void UcitajInfo()
        {
            pbZastava.Image = Ekstenzije.ToImage(odabranaDrzava.Zastava);
            lblNazivDrzave.Text = odabranaDrzava.Naziv;
        }

        private void dgvGradovi_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var odabraniGrad = gradovi[e.RowIndex];

            if (e.ColumnIndex == 2)
            {

                if (odabraniGrad.Status)
                {
                    odabraniGrad.Status = false;
                }
                else
                {
                    odabraniGrad.Status = true;
                }

                db.GradoviIB180079.Update(odabraniGrad);
                db.SaveChanges();

                UcitajGradove();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Validiraj())
            {

                var naziv = txtNaziv.Text; // JABLANICA jablanica Jablanica


                //  jablanica == jablanica
                if (gradovi.Exists(x => x.Naziv.ToLower() == naziv.ToLower()))
                {
                    MessageBox.Show("Grad je vec dodan", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {

                    var noviGrad = new GradoviIB180079()
                    {
                        Naziv = naziv,
                        Status = true,
                        DrzavaId = odabranaDrzava.Id
                    };

                    db.GradoviIB180079.Add(noviGrad);
                }


                db.SaveChanges();
                UcitajGradove();

                txtNaziv.Clear();


            }

        }

        private bool Validiraj()
        {
            return Validator.ProvjeriUnos(txtNaziv, err, Kljucevi.ReqiredValue);
        }

        private async void button2_Click(object sender, EventArgs e)
        {

            // 1. dio 
            // - napravi async
            // - validacija
            // - postavljanje threada
            // - pokretanje threada
            // - sve sto je vezano za combo box mora ici u prvom dijelu 


            if (ValidirajMultithreading())
            {

                Thread thread = new Thread(() => GenerisiGradove());
                thread.Start();

            }

        }

        private void GenerisiGradove()
        {
            // 2. dio
            // - kalkulacije
            // - pohrane
            // - sleep

            var info = "";
            var broj = int.Parse(txtBroj.Text);
            var status = chbStatus.Checked;

            for (int i = 0; i < broj; i++)
            {
                Thread.Sleep(300);
                var noviGrad = new GradoviIB180079()
                {
                    Status = status,
                    DrzavaId = odabranaDrzava.Id,
                    Naziv = $"Grad {i + 1}."
                };

                info += $"{DateTime.Now.ToString("dd.MM HH:mm:ss")} -> dodat grad {noviGrad.Naziv} za državu {odabranaDrzava.Naziv} {Environment.NewLine}";


                db.GradoviIB180079.Add(noviGrad);
                db.SaveChanges();


            }

            // 3. dio
            // - ucitavanje
            // - mbox 
            // - ispis

            Action action = () =>
            {

                UcitajGradove();
                txtInfo.Text = info;
                MessageBox.Show($"Uspješno je generisano {broj} gradova", "Informacija", MessageBoxButtons.OK, MessageBoxIcon.Information);

            };
            BeginInvoke(action);



        }

        private bool ValidirajMultithreading()
        {
            return Validator.ProvjeriUnos(txtBroj, err, Kljucevi.ReqiredValue);
        }

        private void frmGradoviIB180079_FormClosing(object sender, FormClosingEventArgs e)
        {

            DialogResult = DialogResult.OK;

        }
    }
}
