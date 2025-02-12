﻿using FIT.Data;
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
                if (odabraniGrad.Status == true)
                {
                    odabraniGrad.Status = false;
                }
                else
                {
                    odabraniGrad.Status = true;
                }


                db.Entry(odabraniGrad).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();

                UcitajGradove();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Validiraj())
            {

                var naziv = txtNaziv.Text;

                if (gradovi.Exists(x => x.Naziv.ToLower() == naziv.ToLower()))
                {
                    MessageBox.Show("Taj grad je već unesen", "Informacija", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void frmGradoviIB180079_FormClosed(object sender, FormClosedEventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            // 1. dio
            // -- postavimo thread
            // -- pokrenemo thread
            // -- sve sto je vezano za combobox

            if (Validiraj2())
            {
                Thread thread = new Thread(() => GenerisiGradove());
                thread.Start();
            }

        }

        private void GenerisiGradove()
        {
            // 2. dio 
            // -- kalkulacije
            // -- pohranjivanja
            // -- pauziranja/timera

            Thread.Sleep(300);

            var status = chbStatus.Checked; // true ili false
            var broj = int.Parse(txtBroj.Text); // broj
            string info = "";

            for (int i = 0; i < broj; i++)
            {

                var noviGrad = new GradoviIB180079()
                {
                    Naziv = $"Grad {i + 1}.",
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
                // -- ispisi

                UcitajGradove();
                MessageBox.Show($"Generisali ste {broj} gradova","Informacija",MessageBoxButtons.OK,MessageBoxIcon.Information);
                txtInfo.Text = info;



            };
            BeginInvoke(action);



        }

        private bool Validiraj2()
        {
            return Validator.ProvjeriUnos(txtBroj, err, Kljucevi.ReqiredValue);
        }
    }
}
