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
        private DrzaveIB180079 odabranaDrzava; // bit ce null ako radimo dodavanje nove drzave

        public frmNovaDrzavaIB180079() // dft constr. --> za dodvanje nove drzave
        {
            InitializeComponent();
        }

        public frmNovaDrzavaIB180079(DrzaveIB180079 odabranaDrzava) // prima parametar drzava --> za editovanje
        {
            InitializeComponent();
            this.odabranaDrzava = odabranaDrzava;
        }

        private void pbZastava_DoubleClick(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pbZastava.Image = Image.FromFile(openFileDialog1.FileName);
            }
        }

        private void btnSacuvaj_Click(object sender, EventArgs e)
        {
            if (Validiraj())
            {
                var zastava = Ekstenzije.ToByteArray(pbZastava.Image);
                var naziv = txtNaziv.Text;
                var status = chbStatus.Checked; // "false" "true"

                if(odabranaDrzava == null) // dodavanje
                {

                    var novaDrzava = new DrzaveIB180079()
                    {
                        Naziv = naziv,
                        Status = status,
                        Zastava = zastava
                    };

                    db.DrzaveIB180079.Add(novaDrzava);
                }
                else // editovanje
                {
                    odabranaDrzava.Status = status;
                    odabranaDrzava.Naziv = naziv;
                    odabranaDrzava.Zastava = zastava;

                    db.DrzaveIB180079.Update(odabranaDrzava);

                }



                db.SaveChanges();

                DialogResult = DialogResult.OK;

            }
        }

        private bool Validiraj()
        {
            return Validator.ProvjeriUnos(txtNaziv, err, Kljucevi.ReqiredValue) &&
                    Validator.ProvjeriUnos(pbZastava, err, Kljucevi.ReqiredValue);
        }

        private void frmNovaDrzavaIB180079_Load(object sender, EventArgs e)
        {
            UcitajInfo();
        }

        private void UcitajInfo()
        {

            if(odabranaDrzava != null) // editovanje 
            {
                txtNaziv.Text = odabranaDrzava.Naziv;
                chbStatus.Checked = odabranaDrzava.Status;

                pbZastava.Image = Ekstenzije.ToImage(odabranaDrzava.Zastava);
                //pbZastava.Image = odabranaDrzava.Zastava.ToImage();

            }

        }
    }
}
