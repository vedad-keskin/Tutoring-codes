using FIT.Data;
using FIT.Data.IspitIB180079;
using FIT.Infrastructure;
using FIT.WinForms.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging.Abstractions;
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
                .Include(x => x.Drzava)
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
            string currentDirectory = Directory.GetCurrentDirectory();
            string imagePath = Path.Combine(currentDirectory, "wwwroot", "nesto.jpg");


            lblNazivDrzave.Text = $"{imagePath}";
            pbZastava.Image = Ekstenzije.ToImage(odabranaDrzava.Zastava);
            // pbZastava.Image = odabranaDrzava.Zastava.ToImage();
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

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            if (Validiraj())
            {

                var naziv = txtNaziv.Text;

                if (gradovi.Exists(x => x.Naziv.ToLower() == naziv.ToLower()))
                {
                    MessageBox.Show("Grad već postoji u odabranoj državi", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                    db.SaveChanges();
                    txtNaziv.Clear();

                }

                UcitajGradove();


            }
        }

        private bool Validiraj()
        {
            return Validator.ProvjeriUnos(txtNaziv, err, Kljucevi.ReqiredValue);
        }

        private void frmGradoviIB180079_FormClosing(object sender, FormClosingEventArgs e)
        {

            DialogResult = DialogResult.OK;

        }

        private async void btnGenerisi_Click(object sender, EventArgs e)
        {
            // 1. dio 
            // - async
            // - validacija
            // - postavljanje threada
            // - pokretanje threada
            // - sve sto je vezano za combo box mora biti pohranjeno ovdje


            if (ValidirajMultithreading())
            {

                Thread t1 = new Thread(() => GenerisiGradove());
                t1.Start();

            }

        }

        private void GenerisiGradove()
        {
            // 2. dio
            // - sve pohrane
            // - sve kalkulacije
            // - sleep

            var broj = int.Parse(txtBroj.Text);
            var status = chbStatus.Checked;
            var info = "";

            for (int i = 0; i < broj; i++)
            {
                Thread.Sleep(300);

                var noviGrad = new GradoviIB180079()
                {
                    Status = status,
                    Naziv = $"Grad {i + 1}.",
                    DrzavaId = odabranaDrzava.Id
                };
                info += $"{DateTime.Now.ToString("dd.MM HH:mm:ss")} -> dodat grad {noviGrad.Naziv} za državu {odabranaDrzava} {Environment.NewLine}";

                db.GradoviIB180079.Add(noviGrad);
                db.SaveChanges();

            }

            Action action = () =>
            {
                // 3. dio
                // - mbox
                // - ispisi
                // - ucitavanja

                UcitajGradove();
                MessageBox.Show($"Generisali ste {broj} gradova","Informacija",MessageBoxButtons.OK,MessageBoxIcon.Information);
                txtInfo.Text = info;

            };
            BeginInvoke(action);



        }

        private bool ValidirajMultithreading()
        {
            return Validator.ProvjeriUnos(txtBroj, err, Kljucevi.ReqiredValue);
        }
    }
}
