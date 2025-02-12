using FIT.Data;
using FIT.Data.IspitIB180079;
using FIT.Infrastructure;
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
    public partial class frmUvjerenjaIB180079 : Form
    {
        private Student odabraniStudent;
        List<StudentiUvjerenjaIB180079> uvjerenja;
        DLWMSDbContext db = new DLWMSDbContext();


        public frmUvjerenjaIB180079(Student odabraniStudent)
        {
            InitializeComponent();
            this.odabraniStudent = odabraniStudent;
        }

        private void frmUvjerenjaIB180079_Load(object sender, EventArgs e)
        {
            dgvUvjerenja.AutoGenerateColumns = false;

            UcitajUvjerenja();
        }

        private void UcitajUvjerenja()
        {
            uvjerenja = db.StudentiUvjerenjaIB180079
                .Where(x => x.StudentId == odabraniStudent.Id)
                .ToList();

            if (uvjerenja != null)
            {

                dgvUvjerenja.DataSource = null;
                dgvUvjerenja.DataSource = uvjerenja;

            }

            this.Text = $"Broj uvjerenja -> {uvjerenja.Count()}";

        }

        private void button1_Click(object sender, EventArgs e)
        {


            frmNovoUvjerenjeIB180079 frmNovo = new frmNovoUvjerenjeIB180079(odabraniStudent);

            if (frmNovo.ShowDialog() == DialogResult.OK)
            {
                UcitajUvjerenja();
            }
        }

        private void dgvUvjerenja_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var odabranoUvjerenje = uvjerenja[e.RowIndex];

            if(e.ColumnIndex == 5)
            {
                if (MessageBox.Show("Da li ste sigurni da želite izbrisati odabrano uvjerenje ?","Pitanje",MessageBoxButtons.OKCancel,MessageBoxIcon.Question) == DialogResult.OK )
                {
                    db.StudentiUvjerenjaIB180079.Remove(odabranoUvjerenje);
                    db.SaveChanges();

                    UcitajUvjerenja();

                }



            }
        }
    }
}
