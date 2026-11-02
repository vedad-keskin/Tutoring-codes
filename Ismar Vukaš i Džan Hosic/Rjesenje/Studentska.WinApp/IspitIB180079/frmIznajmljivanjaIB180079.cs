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
        KnjigaServis knjigaServis = new KnjigaServis();
        StudentServis studentServis = new StudentServis();


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

            cmbKnjiga.DataSource = knjigaServis.GetAll(); // override .. 

            cmbKnjiga.DisplayMember = "Naziv";

            cmbStudent.DataSource = studentServis.GetAll();

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

            var student = cmbStudent.SelectedItem as Student;
            var knjiga = cmbKnjiga.SelectedItem as KnjigeIB180079;


            if (studentiKnjigeServis.GetAll()
                .Exists(x => x.StudentId == student.Id && 
                x.KnjigaId == knjiga.Id && 
                x.Vracena == false ))
            {

                MessageBox.Show($"Student {student} je već iznajmio knjigu {knjiga}!", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else if (
                studentiKnjigeServis.GetAll()
                .Where(x => x.Vracena == false && x.KnjigaId == knjiga.Id).Count() >= knjiga.BrojPrimjeraka    )
            {


                MessageBox.Show($"Knjiga {knjiga} nema dosuptnih kopija, a ukupno ih je bilo {knjiga.BrojPrimjeraka}!", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {
                var novoIznajmljivanje = new StudentiKnjigeIB180079()
                {

                    //Id = 4,
                    StudentId = student.Id, // salju se u obliku ID 
                                            //Student = student, // FK nikad ne salju
                    KnjigaId = knjiga.Id,
                    DatumIznajmljivanja = DateTime.Now,
                    //DatumVracanja = null,
                    Vracena = false

                };

                studentiKnjigeServis.Add(novoIznajmljivanje);

                UcitajPodatke();

            }






        }
    }

}
