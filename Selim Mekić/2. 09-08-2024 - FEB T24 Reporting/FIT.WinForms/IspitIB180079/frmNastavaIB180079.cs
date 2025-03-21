﻿using FIT.Data.IspitIB180079;
using FIT.Infrastructure;
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
            dgvNastave.AutoGenerateColumns = false;
            lblNazivProstorije.Text = $"{odabranaProstorija.Naziv} - {odabranaProstorija.Oznaka}";
            cbPredmeti.DataSource = db.Predmeti.ToList();

            cbDan.SelectedIndex = 0;
            cbVrijeme.SelectedIndex = 0;

            UcitajNastave();
        }

        private void UcitajNastave()
        {
            nastave = db.NastavaIB180079
                .Where(x => x.ProstorijaId == odabranaProstorija.Id)
                .Include(x => x.Predmet)
                .Include(x => x.Prostorija)
                .ToList();

            if (nastave != null)
            {
                dgvNastave.DataSource = null;
                dgvNastave.DataSource = nastave;
            }
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {

            var dan = cbDan.SelectedItem.ToString(); // "Ponedeljak"
            var vrijeme = cbVrijeme.SelectedItem.ToString(); // "08 - 10"
            var predmet = cbPredmeti.SelectedItem as PredmetiIB180079;  // klasa Predmet


            if(nastave.Exists( x=> x.Dan == dan && x.Vrijeme == vrijeme))
            {
                MessageBox.Show("Nastava postoji na tom danu i u tom vremenu","Upozorenje",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
            }
            else
            {
                var novaNastava = new NastavaIB180079()
                {
                    Vrijeme = vrijeme,
                    Dan = dan,
                    ProstorijaId = odabranaProstorija.Id,
                    PredmetId = predmet.Id,
                    Oznaka = $"{predmet.Naziv} :: {dan} :: {vrijeme}"

                };

                db.NastavaIB180079.Add(novaNastava);
                db.SaveChanges();

            }


            UcitajNastave();


        }
    }
}
