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
        KnjigeServis knjigeServis = new KnjigeServis();

        public frmIznajmljivanjaIB180079()
        {
            InitializeComponent();
        }

        private void frmIznajmljivanjaIB180079_Load(object sender, EventArgs e)
        {
            dgvPodaci.AutoGenerateColumns = false;

            UcitajComboBox();

            UcitajPodatke();


        }

        private void UcitajComboBox()
        {

            cbStudent.DataSource = studentServis.GetAll();

            cbKnjiga.DataSource = knjigeServis.GetAll();

            cbKnjiga.DisplayMember = "Naziv";

        }

        private void UcitajPodatke()
        {




            var podaci = studentiKnjigeServis
                .GetAllIncluded() // _dbContext.StudentiKnjigeIB180079 ------ ToList();
                .ToList(); // ToList();



            dgvPodaci.DataSource = podaci;


        }

        private void btnIznajmi_Click(object sender, EventArgs e)
        {

            var student = cbStudent.SelectedItem as Student;

            var knjiga = cbKnjiga.SelectedItem as KnjigeIB180079;


            if (studentiKnjigeServis
                .GetAll()
                .Exists(x => x.StudentId == student.Id && 
                x.KnjigaId == knjiga.Id &&
                x.Vracena == false )  )
            {

                MessageBox.Show($"Student {student} je već prethodno iznajmio knjigu {knjiga} a prethodno je nije vratio", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else if ( studentiKnjigeServis.GetAll().
                Where(x => x.KnjigaId == knjiga.Id && x.Vracena == false).Count() >= knjiga.BrojPrimjeraka  )
            {

                MessageBox.Show($"Broj primjeraka {knjiga} je {knjiga.BrojPrimjeraka}, nemamo više primjeraka na stanju.", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);


            }
            else
            {


                var novoIznajmljivanje = new StudentiKnjigeIB180079()
                {
                    //Id = 4,
                    StudentId = student.Id,
                    //Student = student,
                    KnjigaId = knjiga.Id,
                    DatumIznajmljivanja = DateTime.Now,
                    Vracena = false
                };

                studentiKnjigeServis.Add(novoIznajmljivanje);

                UcitajPodatke();

            }


        }

        private void frmIznajmljivanjaIB180079_FormClosed(object sender, FormClosedEventArgs e)
        {
            DialogResult = DialogResult.OK;

        }
    }
}
