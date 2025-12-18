using DLWMS.Data;
using DLWMS.Data.IspitIB180079;
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
    public partial class frmRazmjeneIB180079 : Form
    {
        private Student? odabraniStudent;
        DLWMSContext db = new DLWMSContext();

        //public frmRazmjeneIB180079()
        //{
        //    InitializeComponent();
        //}

        public frmRazmjeneIB180079(Student? odabraniStudent)
        {
            InitializeComponent();
            this.odabraniStudent = odabraniStudent;
        }

        private void frmRazmjeneIB180079_Load(object sender, EventArgs e)
        {
            dgvRazmjene.AutoGenerateColumns = false;

            Text = $"Razmjene studenta: {odabraniStudent}";

            UcitajRazmjene();

        }

        private void UcitajRazmjene()
        {

            var razmjene = db.RazmjeneIB180079
                .Include(x => x.Univerzitet.Drzava)
                .Where(x => x.StudentId == odabraniStudent.Id)
                .ToList();


            if (razmjene != null)
            {

                dgvRazmjene.DataSource = null;
                dgvRazmjene.DataSource = razmjene;

            }


        }

        private void dgvRazmjene_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if(e.ColumnIndex == 5)
            {

                var odabranaRazmjena = dgvRazmjene.SelectedRows[0].DataBoundItem as RazmjeneIB180079;

                if (MessageBox.Show($"Da li ste sigurni da želite obrisati podatke o razmjeni {odabraniStudent} na {odabranaRazmjena.UniverzitetInfo}","Upit",MessageBoxButtons.YesNo,MessageBoxIcon.Warning) == DialogResult.Yes)
                {


                    db.RazmjeneIB180079.Remove(odabranaRazmjena);
                    db.SaveChanges();

                    UcitajRazmjene();



                }


            }

        }
    }
}
