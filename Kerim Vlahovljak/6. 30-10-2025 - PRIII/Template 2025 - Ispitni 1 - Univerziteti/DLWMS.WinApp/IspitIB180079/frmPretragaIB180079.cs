using DLWMS.Data;
using DLWMS.Infrastructure;
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

namespace DLWMS.WinApp.IspitIB180079
{
    public partial class frmPretragaIB180079 : Form
    {
        DLWMSContext db = new DLWMSContext();
        public frmPretragaIB180079()
        {
            InitializeComponent();
        }

        private void frmPretragaIB180079_Load(object sender, EventArgs e)
        {
            dgvStudenti.AutoGenerateColumns = false;

            cbSpol.DataSource = db.Spolovi.ToList();

            cbDrzava.DataSource = db.Drzave.ToList();

        }

        private void UcitajStudente()
        {
            // studenti[0] = 1	Denis	Mušić	IB2400001	2024-12-11 13:02:21.1642863	denis.music@fit.ba	tpRYHTp/ep&fQ)i	2	3	BLOB 1	Sarajevo	SA	1	1 1	Bosna i Hercegovina	BIH	1

            // studenti[1] = Jasmin
            // studenti[2] = Zanin

            //var spol = cbSpol.SelectedItem.ToString(); // Naziv
            var spol = cbSpol?.SelectedItem as Spol ?? new Spol(); // Id Naziv Aktivan

            var drzava = cbDrzava?.SelectedItem as Drzava ?? new Drzava(); // Id Naziv Aktivan ... 

            //var imePrezime = txtImePrezime?.Text ?? "";
            var imePrezime = txtImePrezime.Text.ToLower(); // adnan


            var studenti = db.Studenti
                .Include(x => x.Grad.Drzava)
                .Include(x => x.Spol)
                //.Where(x => x.Spol.Naziv == spol)
                .Where(x => x.SpolId == spol.Id)
                .Where(x => x.Grad.DrzavaId == drzava.Id)
                //            adnan . Contains ( adnan )
                .Where(x => x.Ime.ToLower().Contains(imePrezime) || 
                x.Prezime.ToLower().Contains(imePrezime) )
                .ToList();


            dgvStudenti.DataSource = studenti;

            //this.Text = $"Broj prikazanih studenata: {studenti.Count()}";;
            Text = $"Broj prikazanih studenata: {studenti.Count()}";

            if(studenti.Count() == 0 && drzava.Id != 0) // ovaj dio sa drzavom nije obavezan
            {

                MessageBox.Show($"U bazi nisu evidentirani studenti spola {spol}, koji u imenu i prezimenu posjeduju sadržaj {imePrezime}, a koji su državljani {drzava}","Upozorenje",MessageBoxButtons.OK,MessageBoxIcon.Warning);

            }

        }

        private void cbSpol_SelectedIndexChanged(object sender, EventArgs e)
        {
            UcitajStudente();
        }

        private void cbDrzava_SelectedIndexChanged(object sender, EventArgs e)
        {
            UcitajStudente();
        }

        private void txtImePrezime_TextChanged(object sender, EventArgs e)
        {
            UcitajStudente();

        }
    }
}
