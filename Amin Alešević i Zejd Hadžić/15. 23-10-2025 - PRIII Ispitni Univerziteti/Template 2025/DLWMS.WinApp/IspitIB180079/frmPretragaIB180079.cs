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
            // studenti[0] = denis
            // studenti[1] = jasmin
            // studenti[2] = zanin ...

            // 1	Denis	Mušić	IB2400001	2024-12-11 13:02:21.1642863	denis.music@fit.ba	tpRYHTp/ep&fQ)i	2	3	BLOB
            // mora se includati svaka dodatna tabela koja nam treba u ispisu 
            // 1	Bosna i Hercegovina	BIH	1
            // 2	Mostar	MO	1	1
            // 3	*********	0

            //var odabraniSpol = cbSpol.SelectedItem.ToString(); // "Muski" , "Zenski" , "********" .. 
            // dobijamo samo Naziv

            var odabraniSpol = cbSpol?.SelectedItem as Spol ?? new Spol(); // Id = 0 , Naziv = "" , Ak = t
            // Id Naziv Aktivan ... 

            var odabranaDrzava = cbDrzava?.SelectedItem as Drzava ?? new Drzava(); // Id = 0 , Naziv = "" , Ak = t

            //var imePrezime = txtImePrezime?.Text ?? "";

            // Emina -> EMINA
            var odabranoimePrezime = txtImePrezime.Text.ToUpper(); // NULL -> ""


            var studenti = db.Studenti
                .Include(x => x.Spol)
                .Include(x => x.Grad.Drzava)
                //.Where(x => x.Spol.Naziv == odabraniSpol)
                .Where(x => x.SpolId == odabraniSpol.Id)
                .Where(x => x.Grad.DrzavaId == odabranaDrzava.Id)
                //.Where(x => x.Ime == imePrezime)
                //            Emina -> EMINA contains -> EMINA.. Emina .. -> EMINA
                .Where(x => x.Ime.ToUpper().Contains(odabranoimePrezime) ||
                x.Prezime.ToUpper().Contains(odabranoimePrezime))
                .ToList();


            if (studenti != null)
            {

                dgvStudenti.DataSource = null;
                dgvStudenti.DataSource = studenti;

            }

            //this.Text = $"";
            Text = $"Broj prikazanih studenata: {studenti.Count()}";

            //if(studenti.Count() == 0 && odabranaDrzava.Id != 0) // ne morate dodavati provjeru za drzavu
            if (studenti.Count() == 0 && cbDrzava.DataSource != null) // ne morate dodavati provjeru za drzavu
            {

                MessageBox.Show($"U bazi nisu evidentirani studenti spola {odabraniSpol}, koji u imenu i prezimenu posjeduju sadržaj {odabranoimePrezime}, a koji su državljani {odabranaDrzava}.");

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

        private void dgvStudenti_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {

                var odabraniStudent = dgvStudenti.SelectedRows[0].DataBoundItem as Student;


                // 1 NACIN

                //if(odabraniStudent.Aktivan == true)
                //{
                //    odabraniStudent.Aktivan = false;
                //}
                //else
                //{
                //    odabraniStudent.Aktivan= true;
                //}

                // 2 NACIN
                //odabraniStudent.Aktivan = odabraniStudent.Aktivan == true ? false : true;

                // 3 NACIN
                odabraniStudent.Aktivan = !odabraniStudent.Aktivan;

                db.Studenti.Update(odabraniStudent);
                db.SaveChanges();


            }
        }
    }
}
