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
    public partial class frmNovaDrzavaIB180079 : Form
    {
        DLWMSDbContext db = new DLWMSDbContext();
        public frmNovaDrzavaIB180079()
        {
            InitializeComponent();
        }

        private void pbZastava_DoubleClick(object sender, EventArgs e)
        {

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // C:\Users\ASUS\Desktop\C# Repos\Slike helpers\Egpyt.png
                pbZastava.Image = Image.FromFile(openFileDialog1.FileName);

            }

        }

        private void btnSacuvaj_Click(object sender, EventArgs e)
        {
            if (Validiraj())
            {
                
                var naziv = txtNaziv.Text;


                // IMAGE -> BYTE[]
                //var zastava = Ekstenzije.ToByteArray(pbZastava.Image);
                var zastava = pbZastava.Image.ToByteArray();


                var status = chbStatus.Checked; // true false


                var novaDrzava = new DrzaveIB180079()
                {
                    //Id = 5,  PUCA 
                    //Broj = 0, PUCA 

                    Naziv = naziv,
                    Status = status,
                    Zastava = zastava

                };

                db.DrzaveIB180079.Add(novaDrzava);
                db.SaveChanges();

                DialogResult = DialogResult.OK;

            }
        }

        private bool Validiraj()
        {
            return 
                Validator.ProvjeriUnos(pbZastava, err, Kljucevi.ReqiredValue) 
                && 
                Validator.ProvjeriUnos(txtNaziv, err, Kljucevi.ReqiredValue);
        }
    }
}
