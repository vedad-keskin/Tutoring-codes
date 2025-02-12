using FIT.Data;
using FIT.Data.IspitIB180079;
using FIT.Infrastructure;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FIT.WinForms.IspitIB180079
{
    public partial class frmPorukeIB180079 : Form
    {
        private Student student;
        DLWMSDbContext db = new DLWMSDbContext();
        List<StudentiPorukeIB180079> poruke;

        public frmPorukeIB180079(Student student)
        {
            InitializeComponent();
            this.student = student;
        }

        private void frmPorukeIB180079_Load(object sender, EventArgs e)
        {
            dgvPoruke.AutoGenerateColumns = false;
            lblStudent.Text = student.ToString();

            UcitajPoruke();
        }

        private void UcitajPoruke()
        {
            poruke = db.StudentiPorukeIB180079
                .Include(x => x.Predmet)
                .Include(x => x.Student)
                .Where(x => x.StudentId == student.Id
                && x.Validnost >= DateTime.Now)
                .ToList();

            if (poruke != null)
            {
                dgvPoruke.DataSource = null;
                dgvPoruke.DataSource = poruke;

            }

            this.Text = $"Broj poruka: {poruke.Count()}";

        }

        private void btnNovaPoruka_Click(object sender, EventArgs e)
        {
            frmNovaPorukaIB180079 frmNova = new frmNovaPorukaIB180079(student);
            if(frmNova.ShowDialog() == DialogResult.OK)
            {
                UcitajPoruke();
            }
        }

        private void dgvPoruke_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            // TODO brisanje

            var odabranaPoruka = poruke[e.RowIndex];

            if(e.ColumnIndex == 4)
            {

                if (MessageBox.Show("Da li ste sigurni da želite izbrisati odabranu poruku","Pitanje",MessageBoxButtons.OKCancel,MessageBoxIcon.Question) == DialogResult.OK)
                {
                    db.StudentiPorukeIB180079.Remove(odabranaPoruka);
                    db.SaveChanges();

                    UcitajPoruke();

                }


            }

        }
    }
}
