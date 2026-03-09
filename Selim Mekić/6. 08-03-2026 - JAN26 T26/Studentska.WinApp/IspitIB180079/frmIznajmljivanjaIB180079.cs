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

        StudentKnjigaServis studentKnjigaServis = new StudentKnjigaServis();
        StudentServis studentServis = new StudentServis();
        KnjigaServis knjigaServis = new KnjigaServis();
        public frmIznajmljivanjaIB180079()
        {
            InitializeComponent();
        }

        private void frmIznajmljivanjaIB180079_Load(object sender, EventArgs e)
        {
            dgvStudentiKnjige.AutoGenerateColumns = false;

            UcitajComboBox();

            UcitajStudentiKnjige();
        }

        private void UcitajComboBox()
        {
            cbStudent.DataSource = studentServis.GetAll();

            cbKnjiga.DataSource = knjigaServis.GetAll();

            cbKnjiga.DisplayMember = "Naziv";

        }

        private void UcitajStudentiKnjige()
        {

            //                   db.StudentiKnjige.ToList();
            var studentiKnjige = studentKnjigaServis
                .GetAllIncluded()
                .ToList();


            if (studentiKnjige != null)
            {

                dgvStudentiKnjige.DataSource = null;
                dgvStudentiKnjige.DataSource = studentiKnjige;

            }

        }

        private void btnIznajmi_Click(object sender, EventArgs e)
        {


            var student = cbStudent.SelectedItem as Student;

            var knjiga = cbKnjiga.SelectedItem as KnjigeIB180079;


            if (studentKnjigaServis.GetAll()
                .Where(x => x.KnjigaId == knjiga.Id && x.Vracena == false).Count() >= knjiga.BrojPrimjeraka)
            {

                MessageBox.Show($"Nema dovoljan broj primjeraka na stanju", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else if (studentKnjigaServis.GetAll().Exists(x => x.StudentId == student.Id && x.KnjigaId == knjiga.Id && x.Vracena == false))
            {

                MessageBox.Show($"Student {student} je iznajmio ali nije vratio knjigu {knjiga}", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {

                var studentiKnjiga = new StudentiKnjigeIB180079()
                {
                    StudentId = student.Id,
                    KnjigaId = knjiga.Id,
                    DatumIznajmljivanja = DateTime.Now,
                    Vracena = false
                };

                studentKnjigaServis.Add(studentiKnjiga);

                UcitajStudentiKnjige();

            }





        }

        private async void btnGenerisi_Click(object sender, EventArgs e)
        {

            var odabraniStudent = cbStudent.SelectedItem as Student;

            await Task.Run(() => GenerisiIznajmljivanja(odabraniStudent) );


        }

        private void GenerisiIznajmljivanja(Student? odabraniStudent)
        {

            var sveKnjige = knjigaServis.GetAll();

            var info = "";

            var redniBroj = 0;

            for (int i = 0; i < sveKnjige.Count(); i++)
            {

                Thread.Sleep(3000);


                if (!studentKnjigaServis.GetAll().Exists(x => x.StudentId == odabraniStudent.Id && x.KnjigaId == sveKnjige[i].Id))
                {

                    var novoIznajmljivanje = new StudentiKnjigeIB180079()
                    {

                        StudentId = odabraniStudent.Id,
                        KnjigaId = sveKnjige[i].Id,
                        DatumIznajmljivanja = DateTime.Now,
                        Vracena = false

                    };

                    studentKnjigaServis.Add(novoIznajmljivanje);

                    info += $"{++redniBroj}. {odabraniStudent} dodatno zaduzenje {sveKnjige[i]}{Environment.NewLine}";

                }

          

            }



            Action action = () =>
            {

                UcitajStudentiKnjige();

                txtInfo.Text = info;

                MessageBox.Show("Generisanje je uspješno završeno");

            };
            BeginInvoke(action);


        }
    }
}
