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
                .GetAllIncluded()
                .ToList();

            if (podaci != null)
            {

                dgvPodaci.DataSource = null;
                dgvPodaci.DataSource = podaci;

            }

        }

        private void btnIznajmi_Click(object sender, EventArgs e)
        {

            var student = cbStudent.SelectedItem as Student;

            var knjiga = cbKnjiga.SelectedItem as KnjigeIB180079;



            if (knjiga.BrojPrimjeraka <= 
                studentiKnjigeServis.GetAll().Where(x => x.KnjigaId == knjiga.Id && x.Vracena == false).Count()  )
            {
                MessageBox.Show($"Broj primjeraka {knjiga.Naziv} je {knjiga.BrojPrimjeraka}, a vise ih nema na stanju.", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else if (studentiKnjigeServis.GetAll().
                Exists(x => x.StudentId == student.Id && x.KnjigaId == knjiga.Id 
                && x.Vracena == false )       )
            {

                MessageBox.Show($"Student {student} je već iznajmio knjigu {knjiga} a nije je prethodno vratio","Upozorenje",MessageBoxButtons.OK, MessageBoxIcon.Warning);


            }
            else
            {

                var novoIznajmljivanje = new StudentiKnjigeIB180079()
                {

                    StudentId = student.Id,
                    //Student = student,
                    KnjigaId = knjiga.Id,
                    DatumIznajmljivanja = DateTime.Now,
                    //DatumVracanja = null,
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
