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
    public partial class frmNovaProstorijaIB180079 : Form
    {
        DLWMSDbContext db = new DLWMSDbContext();

        // null ako radimo dodavanje , not null ako radimo edit
        private ProstorijeIB180079 odabranaProstorija;

        public frmNovaProstorijaIB180079() // za dodavanje nove prostorije
        {
            InitializeComponent();
        }

        // za modifikaciju postojece prosotorije
        public frmNovaProstorijaIB180079(ProstorijeIB180079 odabranaProstorija)
        {
            InitializeComponent();
            this.odabranaProstorija = odabranaProstorija;
        }






        private void pbLogo_DoubleClick(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pbLogo.Image = Image.FromFile(openFileDialog1.FileName);
            }

        }


        private void btnSacuvaj_Click(object sender, EventArgs e)
        {
            if (Validiraj())
            {
                // IMAGE -> BYTE[]
                var logo = Ekstenzije.ToByteArray(pbLogo.Image);

                var naziv = txtNaziv.Text;
                var oznaka = txtOznaka.Text;

                // STRING -> INT 
                var kapacitet = int.Parse(txtKapacitet.Text);

                if(odabranaProstorija == null) // dodavanje
                {
                    var novaProstorija = new ProstorijeIB180079()
                    {
                        Naziv = naziv,
                        Oznaka = oznaka,
                        Kapacitet = kapacitet,
                        Logo = logo

                    };

                    db.ProstorijeIB180079.Add(novaProstorija);

                }
                else // edit
                {

                    odabranaProstorija.Naziv = naziv;
                    odabranaProstorija.Oznaka = oznaka;
                    odabranaProstorija.Kapacitet = kapacitet;
                    odabranaProstorija.Logo = logo;

                   
                    db.ProstorijeIB180079.Update(odabranaProstorija);

                }



                db.SaveChanges();

                DialogResult = DialogResult.OK;



            }
        }

        private bool Validiraj()
        {
            return Validator.ProvjeriUnos(pbLogo, err, Kljucevi.ReqiredValue)
                &&
                Validator.ProvjeriUnos(txtKapacitet, err, Kljucevi.ReqiredValue)
                &&
                Validator.ProvjeriUnos(txtNaziv, err, Kljucevi.ReqiredValue)
                &&
                Validator.ProvjeriUnos(txtOznaka, err, Kljucevi.ReqiredValue);
        }

        private void frmNovaProstorijaIB180079_Load(object sender, EventArgs e)
        {
            UcitajInfo();
        }

        private void UcitajInfo()
        {

            if(odabranaProstorija != null)
            {
                // BYTE[] -> IMAGE
                pbLogo.Image = Ekstenzije.ToImage(odabranaProstorija.Logo);

                txtNaziv.Text = odabranaProstorija.Naziv;
                txtOznaka.Text = odabranaProstorija.Oznaka;

                // INT -> STRING
                txtKapacitet.Text = odabranaProstorija.Kapacitet.ToString();

            }



        }
    }
}
