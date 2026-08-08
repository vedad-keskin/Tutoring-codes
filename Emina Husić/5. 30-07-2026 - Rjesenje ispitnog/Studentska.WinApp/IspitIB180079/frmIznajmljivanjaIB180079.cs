using Studentska.Data.Entiteti;
using Studentska.Data.IspitIB180079;
using Studentska.Servis.Servisi;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Studentska.WinApp.IspitIB180079
{
    public partial class frmIznajmljivanjaIB180079 : Form
    {
        StudentiKnjigeServis studentiKnjigeServis = new StudentiKnjigeServis();
        StudentServis studentServis = new StudentServis();
        KnjigaServis knjigaServis = new KnjigaServis();
        public frmIznajmljivanjaIB180079()
        {
            InitializeComponent();
        }

        private void frmIznajmljivanjaIB180079_Load(object sender, EventArgs e)
        {
            dgvStudentiKnjige.AutoGenerateColumns = false;

            UcitajStudentiKnjige();

            UcitajComboBox();

        }

        private void UcitajComboBox()
        {

            cmbStudent.DataSource = studentServis.GetAll();

            cmbKnjiga.DataSource = knjigaServis.GetAll();

            cmbKnjiga.DisplayMember = "Naziv";

        }

        private void UcitajStudentiKnjige()
        {
            var studentiKnjige = studentiKnjigeServis.GetAllIncluded();



            if (studentiKnjige != null)
            {

                dgvStudentiKnjige.DataSource = null;
                dgvStudentiKnjige.DataSource = studentiKnjige;

            }



        }

        private void btnIznajmi_Click(object sender, EventArgs e)
        {
            //                         OBJECT 
            var student = cmbStudent.SelectedItem as Student;

            var knjiga = cmbKnjiga.SelectedItem as KnjigeIB180079;



            if (studentiKnjigeServis.GetAll()
                .Exists(x => x.StudentId == student.Id 
                && x.KnjigaId == knjiga.Id && x.Vracena == false))
            {


                MessageBox.Show($"Student {student} je već iznajmio {knjiga} a prethodno je nije vratio", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }else if (studentiKnjigeServis.GetAll().Where(x => x.KnjigaId == knjiga.Id && x.Vracena == false).Count() >= knjiga.BrojPrimjeraka)
            {

                MessageBox.Show($"Svi primjerci knjige {knjiga} su iznajmljeni", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {

                var novoIznajmljivanje = new StudentiKnjigeIB180079()
                {
                    //Id = 1,
                    StudentId = student.Id,
                    //Student = student,
                    KnjigaId = knjiga.Id,
                    //Knjiga = knjiga,
                    DatumIznajmljivanja = DateTime.Now,
                    //DatumVracanja = null,
                    Vracena = false

                };

                studentiKnjigeServis.Add(novoIznajmljivanje);

                UcitajStudentiKnjige();

                //DialogResult = DialogResult.OK;


            }





        }

        private void frmIznajmljivanjaIB180079_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}
