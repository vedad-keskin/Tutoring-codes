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
                //               1    ==  1
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
            pbZastava.Image = odabranaDrzava.Zastava.ToImage();

            lblNazivDrzave.Text = odabranaDrzava.Naziv;

        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            if (Validiraj())
            {

                var naziv = txtNaziv.Text;

                //                        mostar == mostar
                if (gradovi.Exists(x => x.Naziv.ToLower() == naziv.ToLower()))
                {
                    MessageBox.Show($"Grad {naziv} već postoji u državi {odabranaDrzava.Naziv}", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {

                    var noviGrad = new GradoviIB180079()
                    {
                        Naziv = naziv,
                        Status = true,
                        DrzavaId = odabranaDrzava.Id,

                    };

                    db.GradoviIB180079.Add(noviGrad);
                    db.SaveChanges();

                    txtNaziv.Clear();
                    UcitajGradove();

                }





            }
        }

        private bool Validiraj()
        {
            return Validator.ProvjeriUnos(txtNaziv, err, Kljucevi.ReqiredValue);
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

                // gdje hoces da pohranis =   izraz               ? ako je taj izraz true : ako je taj izraz false ; 
                //odabraniGrad.Status = odabraniGrad.Status ? false : true;




                db.GradoviIB180079.Update(odabraniGrad);
                db.SaveChanges();

                UcitajGradove();


            }

        }

        private void frmGradoviIB180079_FormClosed(object sender, FormClosedEventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private async void btnGenerisi_Click(object sender, EventArgs e)
        {
            // 1. dio 
            // -- validacija 
            // -- async/await/task -- thread
            // -- kreiranje threda
            // -- pokretanje threada
            // -- [-----]


            if (ValidirajMultithreading())
            {

                await Task.Run(() => GenerisiGradove());

                //Thread thread = new Thread(() => GenerisiGradove());
                //thread.Start();

            }


        }

        private void GenerisiGradove()
        {
            // 2. dio 
            // -- pohrane
            // -- kalkulacije
            // -- sleep - 300 sec. 

            var broj = int.Parse(txtBroj.Text); // 5
            var status = chbStatus.Checked;
            var info = "";


            for (int i = 0; i < broj; i++) // 0 1 2 3 4 5 .. 
            {
                Thread.Sleep(300);

                var noviGrad = new GradoviIB180079()
                {
                    Naziv = $"Grad {i+1}.",
                    Status = status,
                    DrzavaId = odabranaDrzava.Id

                };

                db.GradoviIB180079.Add(noviGrad);
                db.SaveChanges();

                info += $"{DateTime.Now.ToString("dd.MM HH:mm:ss")} -> dodat grad {noviGrad.Naziv} za drzavu {odabranaDrzava.Naziv} {Environment.NewLine}";


            }


            Action action = () =>
            {
                // 3. dio
                // -- mbox
                // -- ucitavanja
                // -- ispise

                UcitajGradove();
                MessageBox.Show($"Generisano je {broj} gradova","Informacija",MessageBoxButtons.OK,MessageBoxIcon.Information);
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
