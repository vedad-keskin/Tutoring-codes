﻿using DLWMS.Infrastructure;
using DLWMS.WinApp.IspitIB180079;
using DLWMS.WinApp.Izvjestaji;

namespace DLWMS.WinApp
{
    public partial class frmPocetna : Form
    {
        DLWMSContext db = new DLWMSContext();
        public frmPocetna()
        {
            InitializeComponent();
        }

        private void frmPocetna_Load(object sender, EventArgs e)
        {
            lblKonekcijaInfo.Text = $"Broj studenata u bazi -> {db.Studenti.Count()}";
        }

        private void btnIzvjestaj_Click(object sender, EventArgs e)
        {
            new frmIzvjestaji().Show();
        }

        private void btnIspit_Click(object sender, EventArgs e)
        {

            var frmProstorije = new frmProstorijeIB180079();

            frmProstorije.ShowDialog();

        }
    }
}
